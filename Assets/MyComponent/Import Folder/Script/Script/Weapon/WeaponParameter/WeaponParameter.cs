using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParameter : MonoBehaviour
{
    [SerializeField] private float ammunationInMagazine = 0;
    [SerializeField] private float magazineNumber = 0;

    public void SetAmmunation(float ammunationInMagazine, float magazineNumber)
    {
        this.ammunationInMagazine = ammunationInMagazine;
        this.magazineNumber = magazineNumber;
    }

    public (float,float) GetAmmunation()
    {
        return (ammunationInMagazine , magazineNumber);
    }
}
