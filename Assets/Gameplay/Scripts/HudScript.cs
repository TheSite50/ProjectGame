 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//used ,to fix add second crosshair
public class HudScript : MonoBehaviour
{
    [SerializeField] GameObject followCrosshair;
    //[SerializeField] Behavior_hull player;
    private weaponSystem _weapon;
    [SerializeField] GameObject followCrosshair2;
    private weaponSystem _weapon2;
    // Update is called once per frame
    private void Start()
    {
        //_weapon = CreatePlayerInGame.GetWeaponLeft().GetComponent<LocationWeapons>().GetWeaponPosition().weaponLeft;
        //_weapon2 = CreatePlayerInGame.GetWeaponRight().GetComponent<LocationWeapons>().GetWeaponPosition().weaponRight;
        if (CreatePlayerInGame.GetWeaponRight() != null)
        {
            _weapon = CreatePlayerInGame.GetWeaponRight().GetComponent<weaponSystem>();
        }
        else
        {
            _weapon = CreatePlayerInGame.GetArm().GetComponent<LocationWeapons>().GetWeaponPosition().weaponRight;
        }
        if (CreatePlayerInGame.GetWeaponRight() != null)
        {
            _weapon2 = CreatePlayerInGame.GetWeaponLeft().GetComponent<weaponSystem>();
        }
        else
        {
            _weapon2 = CreatePlayerInGame.GetArm().GetComponent<LocationWeapons>().GetWeaponPosition().weaponLeft;
        }
    }
    void Update()
    {
        
        UpdateCrosshairPosition(followCrosshair, _weapon);
        UpdateCrosshairPosition(followCrosshair2, _weapon2);
    }
    void UpdateCrosshairPosition(GameObject crosshair, weaponSystem weapon) 
    {
        crosshair.transform.position = Camera.main.WorldToScreenPoint(weapon.WhereShootLocation());
    }
}


