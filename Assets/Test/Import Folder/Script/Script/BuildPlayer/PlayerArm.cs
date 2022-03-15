using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArm : MonoBehaviour
{
    [SerializeField] private GameObject LeftWeaponSlot;
    [SerializeField] private GameObject RightWeaponSlot;

    public GameObject GetLeftWeapon()
    {
        return LeftWeaponSlot;
    }
    public GameObject GetRightWeapon()
    {
        return RightWeaponSlot;
    }
}
