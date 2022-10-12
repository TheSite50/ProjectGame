using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used not finished
public class W_Minigun : weaponSystem, IReloadable
{
    private AudioSource mechShoot;


    [SerializeField] private WeaponParameter parameter;
    private void Update()
    {
        parameter.SetAmmunation(CurrentAmmoInMag, AmmoInReserve);
        RotateGun();
    }
    private void Start()
    {
        secondsBetweenBullets = 60 / weapon.fireRate;//trzeba przypisaæ bo ustawia siê na 0 nie wiem czmu
        AmmoInReserve = 1000;
        CurrentAmmoInMag = 50;
        parameter.SetAmmunation(CurrentAmmoInMag, AmmoInReserve);


        mechShoot = GetComponent<AudioSource>();
    }
    public W_Minigun(int currentAmmoInMag, int ammoInReserve) 
    {
        CurrentAmmoInMag = currentAmmoInMag;
        AmmoInReserve = ammoInReserve;
        secondsBetweenBullets = 60/weapon.fireRate;
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
        //Debug.Log("ShootInputWorking w_MG");
        if (CurrentAmmoInMag > 0)
        {
            Debug.Log(parameter.GetAmmunation().Item1 + " w_MG");
            //Debug.Log(lastBulletShootTime);
            lastBulletShootTime = Time.realtimeSinceStartup;
            base.Shooting();
            mechShoot.Play();
            CurrentAmmoInMag--;
            yield return new WaitForSeconds(secondsBetweenBullets);
        }
        if (CurrentAmmoInMag == 0) 
        {
            Debug.Log("No Ammo w_MG");
        }
    }
}
