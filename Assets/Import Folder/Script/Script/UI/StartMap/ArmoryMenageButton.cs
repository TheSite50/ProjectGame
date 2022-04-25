using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ArmoryMenageButton : MonoBehaviour
{
    [SerializeField] private GameObject[] slots;

    [SerializeField] private TextMeshProUGUI blueEssenceValue;
    [SerializeField] private TextMeshProUGUI greenEssenceValue;
    //[SerializeField] private GameObject mapMenu;

    // Start is called before the first frame update
    public void GoToMap()
    {
        foreach (GameObject slot in slots)
        {
            if (slot.transform.childCount > 0)
            {
                LoadLevel.SetNextLevel(3);
                SceneManager.LoadScene(2);
            }
            else
            {
                Debug.Log("Brak Elementu");
                return;
            }

        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
 
    }

    private void Update()
    {
        blueEssenceValue.text = GameInformation.GetEssence().blueEssenceValue.ToString();
        greenEssenceValue.text = GameInformation.GetEssence().greenEssenceValue.ToString();
    }

}
