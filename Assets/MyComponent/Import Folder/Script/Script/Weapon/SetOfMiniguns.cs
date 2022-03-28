using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOfMiniguns : MonoBehaviour, IWeapon
{
    private int time = 0;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject weaponMuzzleLeft;
    [SerializeField] GameObject weaponMuzzleRight;

    private WeaponParameter weaponParameter;
    // ammunationInMagazine = 0;
    // magazineNumber = 0;
    private void Awake()
    {
        weaponParameter = GetComponent<WeaponParameter>();
    }

    public void Attack(GameObject muzzle)

    {
        if (weaponParameter.GetAmmunation().Item1 == 0)
        {
            print("You can't shoot!!!");
            if (weaponParameter.GetAmmunation().Item2 == 0)
            {
                print("You can't reload!!!");

            }
        }
        else
        {
            if (time == 10)
            {
                Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
                time = 0;
                weaponParameter.SetAmmunation(weaponParameter.GetAmmunation().Item1 - 1, weaponParameter.GetAmmunation().Item2);
            }
            else
            {
                time++;
            }
        }
    }

   //public (float, float) GetAmunation()
   //{
   //    return (GetComponent<WeaponParameter>().GetAmmunationInMagazine(), GetComponent<WeaponParameter>().GetAmmunationInMagazine().GetMagazineNumber());
   //}

    public GameObject[] WeaponMuzzle()
    {
        return new GameObject[] { weaponMuzzleLeft, weaponMuzzleRight };
    }
}
