using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    public GameObject GetBullet()
    {
        throw new System.NotImplementedException();
    }

    //public void Attack(GameObject muzzle)
    //{
    //    Instantiate(bullet, muzzle.transform);
    //}

    public (GameObject weaponMuzzleLeft, GameObject weaponMuzzleRight) WeaponMuzzle()
    {
        throw new System.NotImplementedException();
    }
}
