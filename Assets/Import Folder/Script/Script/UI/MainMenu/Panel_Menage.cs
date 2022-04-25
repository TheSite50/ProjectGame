using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Menage : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject options;
    public void MainMenu_Button()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
    }
    public void Reset_Button()
    {
        Debug.Log("Reset Settings");
    }
    public void Apply_Button()
    {
        Debug.Log("Apply Settings");
    }


}
