using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject saveGame;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;
   
    public void StartGame()
    {
        mainMenu.SetActive(false);
        saveGame.SetActive(true);
    }
    //public void LoadSave()
    //{
    //    SceneManager.LoadScene(1);
    //}

    public void Options()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }
    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }
    public void CreditsBack()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
