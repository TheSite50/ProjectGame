using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//used not finished
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
}
