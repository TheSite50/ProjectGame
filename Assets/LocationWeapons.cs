using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationWeapons : MonoBehaviour
{
    [SerializeField] private weaponSystem weaponRight;
    [SerializeField] private weaponSystem weaponLeft;


    public (weaponSystem weaponRight ,weaponSystem weaponLeft) GetWeaponPosition()
    {
        return (weaponRight = this.weaponRight, weaponLeft = this.weaponLeft);
    }
}           
