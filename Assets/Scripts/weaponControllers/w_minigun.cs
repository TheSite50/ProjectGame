using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used not finished
public class W_Minigun : weaponSystem, IReloadable
{
    
    private void Update()
    {
        RotateGun();
    }
    private void Start()
    {
        secondsBetweenBullets = 60 / weapon.fireRate;
        AmmoInReserve = 500;
        CurrentAmmoInMag = 50;
    }
    public W_Minigun(int currentAmmoInMag, int ammoInReserve) 
    {
        CurrentAmmoInMag = currentAmmoInMag;
        AmmoInReserve = ammoInReserve;
    }
/*    private IEnumerator _shoot;
    public void TryToShootNextBullet(bool isShooting)
    {
        Debug.Log("Shooting Working");
        if (isShooting)
        {
            if (Time.realtimeSinceStartup >= lastBulletShootTime + secondsBetweenBullets)
            {
                if (_shoot != null)
                    StopCoroutine(_shoot);
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
    }*/
    public override IEnumerator ShootWeapon()
    {
        Debug.Log("ShootInputWorking w_MG");
        if (CurrentAmmoInMag > 0)
        {
            //Debug.Log(CurrentAmmoInMag + " w_MG");
            //Debug.Log(lastBulletShootTime);
            lastBulletShootTime = Time.realtimeSinceStartup;
            base.Shooting();
            CurrentAmmoInMag--;
            yield return new WaitForSeconds(1f);
        }
        if (CurrentAmmoInMag == 0) 
        {
            Debug.Log("No Ammo w_MG");
        }
    }
    public void Reload(bool isReloading) 
    {
        StartCoroutine(Reloading());

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
