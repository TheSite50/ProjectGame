using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReloadable
{
    public void ReloadWeapon(int currentAmmoInMag, int ammoInReserve, int MaxAmmoCount);

}
