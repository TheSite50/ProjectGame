using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSlotItem : MonoBehaviour
{
    static private GameObject Torso;
    static private GameObject Accesories;
    static private GameObject WeaponLeft;
    static private GameObject WeaponRight;
    static private GameObject Arm;
    static private GameObject Legs;

    static public void RespawnItem(ref GameObject spawnObject, ref GameObject buildField , ItemType itemType,GetAndDragItem slotItem , bool isRigtWeapon)
    {
       
        if (spawnObject != null)
        {
            Destroy(spawnObject);
        }
        switch (itemType)
        {
            case ItemType.Weapon:
                if (isRigtWeapon)
                {
                    spawnObject = Instantiate(slotItem.ObjectPrefab(), Arm.GetComponent<MechElement>().GetFieldConect(1).transform);
                    PlayerBuild.AddWeaponRight(slotItem.ObjectPrefab());
                    WeaponRight = spawnObject;
                }
                else
                {
                    spawnObject = Instantiate(slotItem.ObjectPrefab(), Arm.GetComponent<MechElement>().GetFieldConect(0).transform);
                    PlayerBuild.AddWeaponLeft(slotItem.ObjectPrefab());
                    WeaponLeft = spawnObject;
                }
                spawnObject.transform.localPosition = new Vector3(0f, 0f, 0f);
                break;
            case ItemType.Accessories:
                spawnObject = Instantiate(slotItem.ObjectPrefab(), Torso.GetComponent<MechElement>().GetFieldConect(1).transform);
                PlayerBuild.AddAccesories(slotItem.ObjectPrefab());
                Accesories = spawnObject;
                spawnObject.transform.localPosition = new Vector3(0f, 0f, 0f);
                break;
            case ItemType.Hands:
                spawnObject = Instantiate(slotItem.ObjectPrefab(), Torso.GetComponent<MechElement>().GetFieldConect(0).transform);
                PlayerBuild.AddArm(slotItem.ObjectPrefab());
                Arm = spawnObject;
                spawnObject.transform.localPosition = new Vector3(0f, 0f, 0f);
                break;
            case ItemType.Torso:
                spawnObject = Instantiate(slotItem.ObjectPrefab(), Legs.GetComponent<MechElement>().GetFieldConect(0).transform);
                PlayerBuild.AddTorso(slotItem.ObjectPrefab());
                Torso = spawnObject;
                spawnObject.transform.localPosition = new Vector3(0f, 0f, 0f);
                break;
            case ItemType.Legs:
                spawnObject = Instantiate(slotItem.ObjectPrefab(), buildField.transform);
                PlayerBuild.AddLegs(slotItem.ObjectPrefab());
                Legs = spawnObject;
                //SaveBuildField[0] = spawnObject.GetComponent<MechElement>().GetFieldConect(0);

                //SaveBuildField = SpawnObject.transform.GetChild(0).gameObject;
                spawnObject.transform.localPosition = new Vector3(0f, 0f, 0f);
                break;
           default:
               break;
        }
    }
}
