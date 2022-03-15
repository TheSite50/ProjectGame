using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuild : MonoBehaviour
{
    static private GameObject Torso;
    static private GameObject Accesories;
    static private GameObject WeaponLeft;
    static private GameObject WeaponRight;
    static private GameObject Arm;
    static private GameObject Legs;

    static public void AddLegs(GameObject legsObject)
    {
        Legs = legsObject;
    }
    static public void AddArm(GameObject armObject)
    {
        Arm = armObject;
    }
    static public void AddTorso(GameObject torsoObject)
    {
        Torso = torsoObject;
    }
    static public void AddAccesories(GameObject accesoriesObject)
    {
        Accesories = accesoriesObject;
    }
    static public void AddWeaponLeft(GameObject weaponLeftObject)
    {
        WeaponLeft = weaponLeftObject;
    }
    static public void AddWeaponRight(GameObject weaponRightObject)
    {
        WeaponRight = weaponRightObject;
    }
    static public GameObject GetLegs()
    {
        return Legs;
    }
    static public GameObject GetArm()
    {
        return Arm;
    }
    static public GameObject GetTorso()
    {
        return Torso;
    }
    static public GameObject GetAccesories()
    {
        return Accesories;
    }
    static public GameObject GetWeaponLeft()
    {
        return WeaponLeft;
    }
    static public GameObject GetWeaponRight()
    {
        return WeaponRight;
    }

}
