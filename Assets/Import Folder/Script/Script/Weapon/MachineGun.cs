using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{ 
    private int time = 0;
    [SerializeField] GameObject weaponMuzzle;
    [SerializeField] GameObject bullet;
    //public void Attack(GameObject muzzle)
    //{
    //    if(time==20)
    //    {
    //    Instantiate(bullet, muzzle.transform.position,muzzle.transform.rotation);
    //    time = 0; 
    //    }
    //    else
    //    {
    //        time++;
    //    }
    //}

    public (float, float) GetAmunation()
    {
        throw new System.NotImplementedException();
    }

    public GameObject GetBullet()
    {
        throw new System.NotImplementedException();
    }

    public (GameObject weaponMuzzleLeft, GameObject weaponMuzzleRight) WeaponMuzzle()
    {
        return (weaponMuzzle, weaponMuzzle);
    }
}
