using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used
public abstract class weaponSystem : MonoBehaviour, IWeapon , IReloadable
{

    protected float lastBulletShootTime;
    protected float secondsBetweenBullets = 5f;
    public int CurrentAmmoInMag { get; set; }
    public int AmmoInReserve { get; set; }

    [SerializeField] protected so_weapon weapon;
    [SerializeField] protected Behavior_hull hull;
    [SerializeField] protected Transform barrelLocation;
    protected Transform cameraTransform;
    //[SerializeField] protected Transform bulletParent;
    protected bool raycast;
    public int MaxAmmo => weapon.magSize;
    public bool IsWeaponBusy { get; set; }
    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        AmmoInReserve = 999999;

        
    }


    private void Update()
    {
        RotateGun();
    }
    #region Shooting
    private IEnumerator _shoot;
    public void TryToShootNextBullet(bool isShooting) 
    {
        if (isShooting)
        {
            if (Time.realtimeSinceStartup >= lastBulletShootTime + secondsBetweenBullets)
            {
                //Debug.Log(Time.realtimeSinceStartup + "//" + lastBulletShootTime + "//" + secondsBetweenBullets);
                if (_shoot != null)
                {
                    StopCoroutine(_shoot);
                }
                _shoot = ShootWeapon();
                StartCoroutine(_shoot);
            }
        }
        if (!isShooting)
        {
            if (_shoot != null)
            {
                StopCoroutine(_shoot);
                
            }
        }
    }
    public abstract IEnumerator ShootWeapon();
    public void Shooting()
    {
        //Debug.Log("Shooting WS");
        GameObject bullet = Instantiate(weapon.bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        //BulletLogic bulletLogic = bullet.GetComponent<BulletLogic>();
        //if (raycast)//strzela przed siebie dodac rotacje do minigunów by obraca³y siê w strone kursora,dodac kursor pokazujacy gdzie dokladnie teraz poleci pocisk
        //{
        //    bulletLogic.Target = WhereShootLocation();
        //    //bulletLogic.Hit = true;
        //}
        //else
        //{
        //    bulletLogic.Target = barrelLocation.position + barrelLocation.forward * weapon.range;
        //    //bulletLogic.Hit = false;
        //}
    }
    #endregion
    #region rotation
    public void RotateGun() 
    {
        Quaternion targetRotation = Quaternion.Euler(cameraTransform.eulerAngles.x, 0, 0);
        //Debug.Log(targetRotation);
        this.transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, weapon.rotationSpeed * Time.deltaTime);
    }
    public Vector3 WhereShootLocation()//yellow raycast z kamery który nakierowuje mecha gdzie ma patrzeæ
    {
        raycast = Physics.Raycast(barrelLocation.position, barrelLocation.forward, out RaycastHit cameraLookAtPoint, 500);
        Debug.DrawRay(barrelLocation.position, barrelLocation.forward * 500, Color.blue);
        if (raycast)
        {
            return cameraLookAtPoint.point;
        }
        return barrelLocation.forward * 500;
    }

    public void Reload()
    {
        if (AmmoInReserve != 0 && CurrentAmmoInMag != weapon.magSize)
        {
            StartCoroutine(Reloading());
        }
    }
    IEnumerator Reloading()
    {
        IsWeaponBusy = true;
        ReloadWeapon(CurrentAmmoInMag, AmmoInReserve, weapon.magSize);
        yield return new WaitForSeconds(weapon.reloadSpeed);
        Debug.Log("reloading");
        IsWeaponBusy = false;
    }
    public void ReloadWeapon(int currentAmmoInMag, int ammoInReserve, int MaxAmmoCount)
    {
        if (ammoInReserve <= MaxAmmoCount - currentAmmoInMag)
        {
            CurrentAmmoInMag += ammoInReserve;
            AmmoInReserve = 0;
            Debug.Log("reloaded!");
            return;
        }
        AmmoInReserve -= (MaxAmmoCount - currentAmmoInMag);
        CurrentAmmoInMag = MaxAmmoCount;
        Debug.Log("reloaded!");
    }
    #endregion
}
