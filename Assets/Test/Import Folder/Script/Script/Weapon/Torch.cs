using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, IWeapon
{
    [SerializeField] GameObject bullet;
    public void Attack(GameObject muzzle)
    {
        Instantiate(bullet, muzzle.transform);
    }

    public GameObject[] WeaponMuzzle()
    {
        throw new System.NotImplementedException();
    }
}
