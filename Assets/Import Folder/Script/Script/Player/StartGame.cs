using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        if(CreatePlayerInGame.GetTorso().GetComponent<Behavior_hull>())
        CreatePlayerInGame.GetTorso().GetComponent<Behavior_hull>().enabled = true;
        //if(this.GetComponent<PlayerMovementScript>())
        //this.GetComponent<PlayerMovementScript>().enabled = true;
    }

}
