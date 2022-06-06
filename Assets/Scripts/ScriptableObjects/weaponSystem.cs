using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class weaponSystem : MonoBehaviour, IReloadable
{
    [SerializeField] so_weapon weapon;
    [SerializeField] Behavior_hull hull;
    float lastBulletShootTime;
    float secondsBetweenBullets = 1f;
    private Transform cameraTransform;
    [SerializeField] private Transform bulletParent;
    private bool raycast;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }
    private void LateUpdate()
    {
        RotateGun();
    }

    public void TryToShootNextBullet()
    {
        if (Time.realtimeSinceStartup >= lastBulletShootTime + secondsBetweenBullets)
            StartCoroutine(ShootBurstCoroutine());
    }

    IEnumerator ShootBurstCoroutine()
    {

        lastBulletShootTime = Time.realtimeSinceStartup;
        for (int bulletNr = 0; bulletNr < 5; bulletNr++)
        {
            ShootWeapon();
            yield return new WaitForSeconds(0.03f);
        }
    }
    public void ShootWeapon()
    {
        GameObject bullet = Instantiate(weapon.bulletPrefab, weapon.barrelLocation.position, Quaternion.identity, bulletParent);
        BulletLogic bulletLogic = bullet.GetComponent<BulletLogic>();
        if (raycast)//strzela przed siebie dodac rotacje do minigunów by obraca³y siê w strone kursora,dodac kursor pokazujacy gdzie dokladnie teraz poleci pocisk
        {
            bulletLogic.Target = hull.WhereLookLocation();
            bulletLogic.Hit = true;
        }
        else
        {
            bulletLogic.Target = weapon.barrelLocation.position + weapon.barrelLocation.forward * weapon.range;
            bulletLogic.Hit = false;
        }
    }
    public void ReloadWeapon(int currentAmmoInMag, int ammoInReserve, int MaxAmmoCount)
    {
        if (ammoInReserve == 0)
            return;
        if (ammoInReserve <= MaxAmmoCount - currentAmmoInMag)
        {
            currentAmmoInMag += ammoInReserve;
            ammoInReserve = 0;
            return;
        }
        ammoInReserve -= (MaxAmmoCount - currentAmmoInMag);
        currentAmmoInMag = MaxAmmoCount;
    }
    //obracanie 
    public void RotateGun() 
    {
        Quaternion targetRotation = Quaternion.Euler(cameraTransform.eulerAngles.x, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, weapon.rotationSpeed * Time.deltaTime);
    }
}
