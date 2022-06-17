using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameEnd : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.IsPressed())
        {
            GameOverButton();
        }
    }


    public void GameOverButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
}
