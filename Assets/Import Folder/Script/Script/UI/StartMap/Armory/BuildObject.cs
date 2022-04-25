using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildObject : MonoBehaviour
{
    static private GameObject ItemInSlotAccessories;
    static private GameObject ItemInLeftSlotWeapon;
    static private GameObject ItemInRightSlotWeapon;
    static private GameObject ItemInSlotHands;
    static private GameObject ItemInSlotTorso;
    static private GameObject ItemInSlotLegs;

    static private int emptySlot = 6;
    

    static public void AddLegs(GameObject legsObject)
    {
        ItemInSlotLegs = legsObject;
        emptySlot--;
        if (emptySlot==0)
        {
            BuildMech();
        }
    }
    static public void AddTorso(GameObject torsoObject)
    {
        ItemInSlotTorso = torsoObject;
        emptySlot--;
        if (emptySlot == 0)
        {
            BuildMech();
        }
    }
    static public void AddHands(GameObject handObject)
    {
        ItemInSlotHands = handObject;
        emptySlot--;
        if (emptySlot == 0)
        {
            BuildMech();
        }
    }
    static public void AddLeftWeapon(GameObject leftWeaponObject)
    {
        ItemInLeftSlotWeapon = leftWeaponObject;
        emptySlot--;
        if (emptySlot == 0)
        {
            BuildMech();
        }
    }
    static public void AddRightWeapon(GameObject rightWeaponObject)
    {
        ItemInRightSlotWeapon = rightWeaponObject;
        emptySlot--;
        if (emptySlot == 0)
        {
            BuildMech();
        }
    }
    static public void AddAccesories(GameObject accesoriesObject)
    {
        ItemInSlotAccessories = accesoriesObject;
        emptySlot--;
        if (emptySlot == 0)
        {
            BuildMech();
        }
    }


    static private void BuildMech()
    {

    }
}
