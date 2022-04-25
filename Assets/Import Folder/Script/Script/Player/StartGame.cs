using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        if(CreatePlayerInGame.GetLegs().GetComponent<LowerPartScript>())
        CreatePlayerInGame.GetLegs().GetComponent<LowerPartScript>().enabled = true;
        if(CreatePlayerInGame.GetTorso().GetComponent<UpperPartScript>())
        CreatePlayerInGame.GetTorso().GetComponent<UpperPartScript>().enabled = true;
    }

}
