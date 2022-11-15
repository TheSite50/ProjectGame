using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private StopGame stop;
    [SerializeField] private Canvas options;

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
    public void Armorry()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Options()
    {
        options.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void Continue()
    {
        this.gameObject.SetActive(false);
        stop.StartGameElement();
    }

}
