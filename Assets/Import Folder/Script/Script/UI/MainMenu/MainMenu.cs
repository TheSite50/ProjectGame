using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;
    public void StartGame()
    {
        SceneManager.LoadScene("StartMap");
    }

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
