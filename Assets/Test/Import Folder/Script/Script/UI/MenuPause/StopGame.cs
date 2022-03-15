using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGame : MonoBehaviour
{
    [SerializeField] private GameObject[] tabElements;
    [SerializeField] private GameObject pauseMenu;
    private bool activePause = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (activePause == true)
            {                
                StopGameElement();
                activePause = false;
            }
            else
            {
                StartGameElement();
                activePause = true;
            }
        }
    }

    public void StopGameElement()
    {
        foreach(GameObject element in tabElements)
        {
            element.SetActive(false);
        }
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void StartGameElement()
    {
        foreach (GameObject element in tabElements)
        {
            element.SetActive(true);
        }
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
