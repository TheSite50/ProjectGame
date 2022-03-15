using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayerInGame : MonoBehaviour
{
    static private GameObject Torso;
    static private GameObject Accesories;
    static private GameObject WeaponLeft;
    static private GameObject WeaponRight;
    static private GameObject Arm;
    static private GameObject Legs;
    
    // Start is called before the first frame update
    void Awake()
    {
        print(PlayerBuild.GetLegs());
        if (PlayerBuild.GetLegs() != null)
        {
            Legs = Instantiate(PlayerBuild.GetLegs(), this.gameObject.transform);
            if (PlayerBuild.GetTorso() != null)
            {
                Torso = Instantiate<GameObject>(PlayerBuild.GetTorso(), Legs.GetComponent<MechElement>().GetFieldConect(0).transform);
                if (PlayerBuild.GetArm() != null)
                {
                    Arm = Instantiate<GameObject>(PlayerBuild.GetArm(), Torso.GetComponent<MechElement>().GetFieldConect(0).transform);
                    if (PlayerBuild.GetWeaponLeft() != null)
                    {
                        WeaponLeft = Instantiate<GameObject>(PlayerBuild.GetWeaponLeft(), Arm.GetComponent<MechElement>().GetFieldConect(0).transform);

                    }
                    if (PlayerBuild.GetWeaponRight() != null)
                    {
                        WeaponRight = Instantiate<GameObject>(PlayerBuild.GetWeaponRight(), Arm.GetComponent<MechElement>().GetFieldConect(1).transform);
                    }
                }
                if (PlayerBuild.GetAccesories() != null)
                {
                    Accesories = Instantiate<GameObject>(PlayerBuild.GetAccesories(), Torso.GetComponent<MechElement>().GetFieldConect(1).transform);
                }

            }

        }
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
