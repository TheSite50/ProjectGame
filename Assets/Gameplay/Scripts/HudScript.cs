 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudScript : MonoBehaviour
{
    [SerializeField] GameObject followCrosshair;
    //[SerializeField] UpperPartScript player;
    private UpperPartScript player;
     GameObject barrelLocation;

    private void Start()
    {
        player = CreatePlayerInGame.GetTorso().GetComponent<UpperPartScript>();
        //error repair
        barrelLocation = CreatePlayerInGame.GetArm().GetComponent<IWeapon>().WeaponMuzzle().weaponMuzzleLeft;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateCrosshairPosition();
    }
    void UpdateCrosshairPosition() 
    {
        followCrosshair.transform.position = Camera.main.WorldToScreenPoint(player.whereLookLocation);
    }
}


