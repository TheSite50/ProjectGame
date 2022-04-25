using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParameter : MonoBehaviour
{
    [SerializeField] private int ammunationInMagazine = 0;
    [SerializeField] private int magazineNumber = 0;

    public void SetAmmunation(int ammunationInMagazine, int magazineNumber)
    {
        this.ammunationInMagazine = ammunationInMagazine;
        this.magazineNumber = magazineNumber;
    }
    public void AddAmmunation(int ammunation, int magazine)
    {
        this.ammunationInMagazine += ammunation;
        this.magazineNumber += magazine;
    }

    public (int,int) GetAmmunation()
    {
        return (ammunationInMagazine , magazineNumber);
    }
}
