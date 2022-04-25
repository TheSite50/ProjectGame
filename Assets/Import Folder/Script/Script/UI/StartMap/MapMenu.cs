using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] slots;
    [SerializeField] private GameObject armoryMenu;
    
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void BackToArmory()
    {
        armoryMenu.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
