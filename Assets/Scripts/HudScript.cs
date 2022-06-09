 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudScript : MonoBehaviour
{
    [SerializeField] GameObject followCrosshair;
    [SerializeField] Behavior_hull player;

    
    // Update is called once per frame
    void Update()
    {
        UpdateCrosshairPosition();
    }
    void UpdateCrosshairPosition() 
    {
        followCrosshair.transform.position = Camera.main.WorldToScreenPoint(player.WhereLookLocation());
    }
}


