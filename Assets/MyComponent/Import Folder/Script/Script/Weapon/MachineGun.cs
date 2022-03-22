using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour, IWeapon
{
    private int time = 0;
    [SerializeField] GameObject weaponMuzzle;
    [SerializeField] GameObject bullet;
    public void Attack(GameObject muzzle)
    {
        if(time==20)
        {
        Instantiate(bullet, muzzle.transform.position,muzzle.transform.rotation);
        time = 0; 
        }
        else
        {
            time++;
        }
    }

    public GameObject[] WeaponMuzzle()
    {
        return new GameObject[] { weaponMuzzle };
    }
}
