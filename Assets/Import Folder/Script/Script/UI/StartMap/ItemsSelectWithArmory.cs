using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSelectWithArmory : MonoBehaviour
{

    [SerializeField] GameObject Item_Accessories;
    [SerializeField] GameObject Item_Weapon;
    [SerializeField] GameObject Item_Hands;
    [SerializeField] GameObject Item_Torso;
    [SerializeField] GameObject Item_Legs;

    public void Accessories()
    {
        Item_Accessories.SetActive(true);
        Item_Weapon.SetActive(false);
        Item_Hands.SetActive(false);
        Item_Torso.SetActive(false);
        Item_Legs.SetActive(false);
    }
    public void Weapon()
    {
        Item_Weapon.SetActive(true);
        Item_Accessories.SetActive(false);
        Item_Hands.SetActive(false);
        Item_Torso.SetActive(false);
        Item_Legs.SetActive(false);
    }
    public void Hands()
    {
        Item_Hands.SetActive(true);
        Item_Weapon.SetActive(false);
        Item_Accessories.SetActive(false);
        Item_Torso.SetActive(false);
        Item_Legs.SetActive(false);
    }
    public void Torso()
    {
        Item_Torso.SetActive(true);
        Item_Weapon.SetActive(false);
        Item_Accessories.SetActive(false);
        Item_Hands.SetActive(false);
        Item_Legs.SetActive(false);
    }
    public void Legs()
    {
        Item_Legs.SetActive(true);
        Item_Weapon.SetActive(false);
        Item_Accessories.SetActive(false);
        Item_Hands.SetActive(false);
        Item_Torso.SetActive(false);
    }
}
