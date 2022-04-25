using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HpBuff : MonoBehaviour
{
    [SerializeField] private float buffStrenght=20f;
    private GameObject player;
    private void Awake()
    {
        player = PlayerStats.SendPlayer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            player.GetComponent<IHp>().SetHp(buffStrenght);
            Destroy(this.gameObject);
        }
    }
}
