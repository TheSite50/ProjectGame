using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon 
{
    GameObject[] WeaponMuzzle();
    void Attack(GameObject muzzle);
}
