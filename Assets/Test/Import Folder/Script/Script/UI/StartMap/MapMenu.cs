using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] slots;
    [SerializeField] private GameObject armoryMenu;
    // Start is called before the first frame update
    public void StartGame()
    {
        print(PlayerBuild.GetLegs());
        foreach (GameObject slot in slots)
        {
            if (slot.transform.childCount > 0)
            {

            }
            else
            {
                Debug.Log("Brak Elementu");
                return;
            }

        }
        
        SceneManager.LoadScene("DesertMap");
    }
    public void BackToArmory()
    {
        armoryMenu.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
