using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOfMiniguns : MonoBehaviour, IWeapon
{
    private int time = 0;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject weaponMuzzleLeft;
    [SerializeField] GameObject weaponMuzzleRight;
    public void Attack(GameObject muzzle)
    {
        if (time == 10)
        {
            Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
            time = 0;
        }
        else
        {
            time++;
        }
    }

    public GameObject[] WeaponMuzzle()
    {
        return new GameObject[] { weaponMuzzleLeft, weaponMuzzleRight };
    }
}
