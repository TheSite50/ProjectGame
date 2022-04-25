using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBuff : MonoBehaviour
{
    [SerializeField] private int buffValue = 2;
    private GameObject player;
    private void Awake()
    {
        player = PlayerStats.SendPlayer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            player.GetComponent<PlayerStats>().AddAmunation(buffValue);
            Destroy(this.gameObject);
        }
    }


}
