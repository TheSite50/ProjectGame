using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class W_BurstGun : weaponSystem, IReloadable
{
    bool isReloading = false;
    private void Update()
    {
        RotateGun();
    }
    public override IEnumerator ShootWeapon()
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
                base.Shooting();
                CurrentAmmoInMag--;
                yield return new WaitForSeconds(60 / weapon.fireRate);
            }
        }
    }
    public void Reload(bool isReloading)
    {
        StartCoroutine(Reloading());

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
