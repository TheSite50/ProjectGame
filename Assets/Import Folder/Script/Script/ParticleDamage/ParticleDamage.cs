using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    private float damage = 10f;
    private GameObject player;
    private void Awake()
    {
        player = PlayerStats.SendPlayer();
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.layer == 8)
        {
            player.GetComponent<PlayerStats>().SetHp(-damage);
            print("I m here");
            
            
        }
    }
}
