using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class weaponSystem : MonoBehaviour, IWeapon
{
    [SerializeField] protected InputScript _input;
    [SerializeField] protected so_weapon weapon;
    [SerializeField] protected Behavior_hull hull;

    protected Transform cameraTransform;
    [SerializeField] protected Transform bulletParent;
    protected bool raycast;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }
    private void Update()
    {
        RotateGun();
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
    #region Shooting
    public abstract void TryToShootNextBullet();
    public void ShootWeapon()
    {
        GameObject bullet = Instantiate(weapon.bulletPrefab, weapon.barrelLocation.position, Quaternion.identity, bulletParent);
        BulletLogic bulletLogic = bullet.GetComponent<BulletLogic>();
        if (raycast)//strzela przed siebie dodac rotacje do minigunów by obraca³y siê w strone kursora,dodac kursor pokazujacy gdzie dokladnie teraz poleci pocisk
        {
            bulletLogic.Target = WhereShootLocation();
            bulletLogic.Hit = true;
        }
        else
        {
            bulletLogic.Target = weapon.barrelLocation.position + weapon.barrelLocation.forward * weapon.range;
            bulletLogic.Hit = false;
        }
    }
    #endregion
    #region rotation
    public void RotateGun() 
    {
        Quaternion targetRotation = Quaternion.Euler(cameraTransform.eulerAngles.x, 0, 0);
        Debug.Log(targetRotation);
        this.transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, weapon.rotationSpeed * Time.deltaTime);
        //Debug.Log(this.transform.rotation);
        //Vector3 targetPoint = new Vector3(hull.WhereLookLocation().x, 0, 0);
        //this.transform.LookAt(targetPoint);
    }
    public Vector3 WhereShootLocation()//yellow raycast z kamery który nakierowuje mecha gdzie ma patrzeæ
    {
        raycast = Physics.Raycast(weapon.barrelLocation.position, weapon.barrelLocation.forward, out RaycastHit cameraLookAtPoint, 500);
        Debug.DrawRay(weapon.barrelLocation.position, weapon.barrelLocation.forward * 500, Color.blue);
        if (raycast)
        {
            return cameraLookAtPoint.point;
        }
        return weapon.barrelLocation.forward * 500;
    }
    #endregion
}
