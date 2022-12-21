using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBuff : MonoBehaviour
{
    [SerializeField] private int buffValue = 2;
    private GameObject player;
    private void Start()
    {
        player = PlayerStats.SendPlayer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            player.gameObject.GetComponent<PlayerStats>().AddAmunation(buffValue);
            Destroy(this.gameObject);
        }
    }


}
