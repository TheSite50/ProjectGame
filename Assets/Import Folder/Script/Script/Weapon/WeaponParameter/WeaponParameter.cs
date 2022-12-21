using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParameter : MonoBehaviour
{
    [SerializeField] private int ammunationInMagazine = 0;
    [SerializeField] private int magazineNumber = 0;

    public void SetAmmunation(int ammunationInMagazine,int magazineNumber)
    {
        this.ammunationInMagazine = ammunationInMagazine;
        this.magazineNumber = magazineNumber;
    }
    public void AddAmmunation(int ammunation, int magazine)
    {
        //this.ammunationInMagazine += ammunation;
        //this.magazineNumber += magazine;
        //print(this.magazineNumber);
        if (CreatePlayerInGame.GetWeaponLeft() != null)
        {
            CreatePlayerInGame.GetWeaponLeft().GetComponent<LocationWeapons>().GetWeaponPosition().weaponLeft.gameObject.GetComponent<weaponSystem>().CurrentAmmoInMag+=ammunation;
            CreatePlayerInGame.GetWeaponLeft().GetComponent<LocationWeapons>().GetWeaponPosition().weaponLeft.gameObject.GetComponent<weaponSystem>().AmmoInReserve += magazine;
        }
        else
        {
            CreatePlayerInGame.GetArm().GetComponent<LocationWeapons>().GetWeaponPosition().weaponLeft.gameObject.GetComponent<weaponSystem>().CurrentAmmoInMag += ammunation;
            CreatePlayerInGame.GetArm().GetComponent<LocationWeapons>().GetWeaponPosition().weaponLeft.gameObject.GetComponent<weaponSystem>().AmmoInReserve += magazine;

        }
        if (CreatePlayerInGame.GetWeaponRight() != null)
        {
            CreatePlayerInGame.GetWeaponRight().GetComponent<LocationWeapons>().GetWeaponPosition().weaponRight.gameObject.GetComponent<weaponSystem>().CurrentAmmoInMag += ammunation;
            CreatePlayerInGame.GetWeaponRight().GetComponent<LocationWeapons>().GetWeaponPosition().weaponRight.gameObject.GetComponent<weaponSystem>().AmmoInReserve += magazine;

        }
        else
        {
            CreatePlayerInGame.GetArm().GetComponent<LocationWeapons>().GetWeaponPosition().weaponRight.gameObject.GetComponent<weaponSystem>().CurrentAmmoInMag += ammunation;
            CreatePlayerInGame.GetArm().GetComponent<LocationWeapons>().GetWeaponPosition().weaponRight.gameObject.GetComponent<weaponSystem>().AmmoInReserve += magazine;
        }
    }
   
    public (int,int) GetAmmunation()
    {
        return (ammunationInMagazine , magazineNumber);
    }
}
