using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Minigun : weaponSystem, IReloadable
{
    float lastBulletShootTime;
    float secondsBetweenBullets = 1f;
    int CurrentAmmoInMag;
    int AmmoInReserve;
    public W_Minigun(int currentAmmoInMag, int ammoInReserve) 
    {
        CurrentAmmoInMag = currentAmmoInMag;
        AmmoInReserve = ammoInReserve;
    } 
    public override void TryToShootNextBullet()
    {
        if (Time.realtimeSinceStartup >= lastBulletShootTime + secondsBetweenBullets)
            StartCoroutine(ShootFullAutoCoroutine());
    }
    IEnumerator ShootFullAutoCoroutine()
    {
        if (CurrentAmmoInMag > 0)
        {
            lastBulletShootTime = Time.realtimeSinceStartup;
            ShootWeapon();
            CurrentAmmoInMag--;
            yield return new WaitForSeconds(60 / weapon.fireRate);
        }
    }

    IEnumerator Reloading() 
    {
        ReloadWeapon(CurrentAmmoInMag, AmmoInReserve, weapon.magSize);
        yield return new WaitForSeconds(weapon.reloadSpeed);
    }
    public void ReloadWeapon(int currentAmmoInMag, int ammoInReserve, int MaxAmmoCount)
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
