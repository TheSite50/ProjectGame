 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudScript : MonoBehaviour
{
    [SerializeField] GameObject followCrosshair;
    [SerializeField] UpperPartScript player;
    [SerializeField] Camera camera;
    // Update is called once per frame
    void Update()
    {
        followCrosshair.transform.position = camera.WorldToScreenPoint(player.transform.forward * 500);
        //Debug.Log(followCrosshair.transform.position);   
       
    }
}
