using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//used
public interface IReloadable
{
    public void Reload();
    public void ReloadWeapon(int currentAmmoInMag, int ammoInReserve, int MaxAmmoCount);

}
