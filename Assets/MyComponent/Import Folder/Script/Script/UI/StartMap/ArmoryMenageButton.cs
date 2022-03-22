using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ArmoryMenageButton : MonoBehaviour
{
    [SerializeField] private GameObject[] slots;
    [SerializeField] private GameObject mapMenu;

    // Start is called before the first frame update
    public void GoToMap()
    {
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
        //SceneManager.LoadScene("DesertMap");
        mapMenu.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
