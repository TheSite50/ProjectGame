using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_BurstGun : weaponSystem, IReloadable
{
    float lastBulletShootTime;
    private float secondsBetweenBullets = 1;
    int CurrentAmmoInMag;
    int AmmoInReserve;
    bool isReloading = false;
    public override void TryToShootNextBullet()
    {
        if (Time.realtimeSinceStartup >= lastBulletShootTime + secondsBetweenBullets)
            StartCoroutine(ShootBurstCoroutine());
    }
    IEnumerator ShootBurstCoroutine()
    {
        if (CurrentAmmoInMag > 0 && !isReloading)
        {
            lastBulletShootTime = Time.realtimeSinceStartup;
            for (int bulletNr = 0; bulletNr < weapon.burstCount; bulletNr++)
            {
                if (CurrentAmmoInMag > 0)
                {
                    yield return null;
                }
                ShootWeapon();
                CurrentAmmoInMag--;
                yield return new WaitForSeconds(60 / weapon.fireRate);
            }
        }
    }
    IEnumerator Reloading()
    {
        isReloading = true;
        ReloadWeapon(CurrentAmmoInMag, AmmoInReserve, weapon.magSize);
        yield return new WaitForSeconds(weapon.reloadSpeed);
        isReloading = false;
    }
    public void ReloadWeapon(int currentAmmoInMag, int ammoInReserve, int MaxAmmoCount)
    {
        if (!isReloading)
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

}
