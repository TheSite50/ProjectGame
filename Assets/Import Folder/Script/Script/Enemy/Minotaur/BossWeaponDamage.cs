using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponDamage : MonoBehaviour
{
    [SerializeField] private float damage = 30f;
    private GameObject player;
    private void Start()
    {
        player = PlayerStats.SendPlayer();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            player.GetComponent<PlayerStats>().SetHp(-damage);
        }
    }
    
}
