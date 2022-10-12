using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBallControll : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(PlayerStats.SendPlayer().transform);
    }
}
