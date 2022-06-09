using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.IsPressed())
        {
            GameOverButton();
        }
    }


    public void GameOverButton()
    {
        SceneManager.LoadScene(0);
        
    }
}
