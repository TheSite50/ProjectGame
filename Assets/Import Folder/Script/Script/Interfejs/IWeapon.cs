using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon 
{
    (GameObject weaponMuzzleLeft, GameObject weaponMuzzleRight) WeaponMuzzle();
    GameObject GetBullet();
    //void Attack(GameObject muzzle);
}
