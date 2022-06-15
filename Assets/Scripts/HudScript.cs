 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//used ,to fix add second crosshair
public class HudScript : MonoBehaviour
{
    [SerializeField] GameObject followCrosshair;
    [SerializeField] Behavior_hull player;
    [SerializeField] private weaponSystem _weapon;
    [SerializeField] GameObject followCrosshair2;
    [SerializeField] private weaponSystem _weapon2;
    // Update is called once per frame
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


