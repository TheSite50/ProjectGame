using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class W_Minigun : weaponSystem, IReloadable
{
    float lastBulletShootTime;
    float secondsBetweenBullets = 5f;
    int CurrentAmmoInMag;
    int AmmoInReserve;
    private void Update()
    {
        RotateGun();
    }
    private void Start()
    {
        AmmoInReserve = 500;
        CurrentAmmoInMag = 50;
    }
    public W_Minigun(int currentAmmoInMag, int ammoInReserve) 
    {
        CurrentAmmoInMag = currentAmmoInMag;
        AmmoInReserve = ammoInReserve;
    } 
    public override void TryToShootNextBullet()
    {
        Debug.Log("Shooting Working");
        if (Time.realtimeSinceStartup >= lastBulletShootTime + secondsBetweenBullets)
            StartCoroutine(ShootWeapon());
    }
    IEnumerator ShootWeapon()
    {
        //Debug.Log("ShootInputWorking");
        if (CurrentAmmoInMag > 0)
        {
            lastBulletShootTime = Time.realtimeSinceStartup;
            base.Shooting();
            CurrentAmmoInMag--;
            Debug.Log(CurrentAmmoInMag);
            yield return new WaitForSeconds(1f);
        }
        if (CurrentAmmoInMag == 0) 
        {
            Debug.Log("No Ammo");
        }
    }
    public override void Reload(bool isReloading) 
    {
        StartCoroutine(Reloading());

    }
    IEnumerator Reloading() 
    {
        ReloadWeapon(CurrentAmmoInMag, AmmoInReserve, weapon.magSize);
        yield return new WaitForSeconds(weapon.reloadSpeed);
    }
    public override void ReloadWeapon(int currentAmmoInMag, int ammoInReserve, int MaxAmmoCount)
    {
        if (ammoInReserve == 0)
            return;
        if (ammoInReserve <= MaxAmmoCount - currentAmmoInMag)
        {
            CurrentAmmoInMag += ammoInReserve;
            AmmoInReserve = 0;
            return;
        }
        AmmoInReserve -= (MaxAmmoCount - currentAmmoInMag);
        CurrentAmmoInMag = MaxAmmoCount;
    }

}
