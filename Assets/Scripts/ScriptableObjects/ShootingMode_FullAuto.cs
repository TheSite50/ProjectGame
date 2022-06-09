using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMode_FullAuto : ShootingMode
{
    public override void Shoot(weaponSystem weapon)
    {
        weapon.TryToShootNextBullet();
    }
}
