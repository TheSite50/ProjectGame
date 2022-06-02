using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportSettings : MonoBehaviour
{
    [SerializeField] private int level = 2;
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer ==8)
        {
            LoadLevel.SetNextLevel(level);  
            SceneManager.LoadScene(2);
        }
    }
}
