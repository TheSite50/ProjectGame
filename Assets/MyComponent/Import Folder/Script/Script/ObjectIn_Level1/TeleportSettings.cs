using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportSettings : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        {
            LoadLevel.SetNextLevel(4);  
            SceneManager.LoadScene(2);
        }
    }
}
