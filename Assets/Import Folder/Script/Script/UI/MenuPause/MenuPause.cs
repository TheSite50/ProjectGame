using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private StopGame stop;
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        
    }
    public void Armorry()
    {
        SceneManager.LoadScene("StartMap");
    }
    public void Options()
    {
        
    }
    public void Continue()
    {
        this.gameObject.SetActive(false);
        stop.StartGameElement();
    }

}
