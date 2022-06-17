using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StopGame : MonoBehaviour
{
    [SerializeField] private GameObject[] tabElements;
    [SerializeField] private GameObject pauseMenu;
    private bool activePause = false;
    // Update is called once per frame
    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        if(Keyboard.current.escapeKey.IsPressed())
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
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void StartGameElement()
    {
        foreach (GameObject element in tabElements)
        {
            element.SetActive(true);
        }
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
