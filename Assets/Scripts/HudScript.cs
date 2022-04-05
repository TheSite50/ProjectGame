 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudScript : MonoBehaviour
{
    [SerializeField] GameObject followCrosshair;
    [SerializeField] UpperPartScript player;
    [SerializeField] GameObject barrelLocation;
    
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(barrelLocation.transform.position, transform.forward, out RaycastHit desiredTarget, Mathf.Infinity))
        {
            followCrosshair.transform.position = Camera.main.WorldToScreenPoint(player._desiredShootLocation);
            
            //Debug.Log(followCrosshair.transform.localScale);

        }
    }
}


