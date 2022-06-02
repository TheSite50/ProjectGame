using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerData : MonoBehaviour
{
    private static float playerHp=1000;
    private GameObject player;
    private void Awake()
    {
       
    }
    private void Start()
    {
        
        player = PlayerStats.SendPlayer();
    }
    public static float SendHp()
    {
        return playerHp;
    }
    // Update is called once per frame
    void Update()
    {
        playerHp = player.GetComponent<PlayerStats>().GetHp();
        
    }
}
