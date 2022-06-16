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
    public W_BurstGun(int currentAmmoInMag, int ammoInReserve)
    {
        CurrentAmmoInMag = currentAmmoInMag;
        AmmoInReserve = ammoInReserve;
        secondsBetweenBullets = 60 / weapon.fireRate;
    }
    private void Start()
    {
        secondsBetweenBullets = 60 / weapon.fireRate;//trzeba przypisaæ bo ustawia siê na 0 nie wiem czmu
        AmmoInReserve = 500;
        CurrentAmmoInMag = 50;
    }
    public override IEnumerator ShootWeapon()
    {
        if (CurrentAmmoInMag > 0)
        {
            Debug.Log("Shooting BurstGun");
            lastBulletShootTime = Time.realtimeSinceStartup;
            for (int bulletNr = 0; bulletNr < weapon.burstCount; bulletNr++)
            {
                if (CurrentAmmoInMag > 0)
                {
                    Debug.Log("BurstFire");
                    base.Shooting();
                    CurrentAmmoInMag--;
                    yield return new WaitForSeconds(60 / weapon.fireRate);
                }
            }
            yield return new WaitForSeconds(1f);
        }
        else if (CurrentAmmoInMag == 0)
        {
            Debug.Log("No Ammo in burstgun w_MG");
        }
        else 
        {
            Debug.Log("Error less ammo than available");
        }
    }
}
