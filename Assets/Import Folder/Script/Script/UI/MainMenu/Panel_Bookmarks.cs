using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Bookmarks : MonoBehaviour
{
    [SerializeField] private GameObject graphic;
    [SerializeField] private GameObject audioButton;
    [SerializeField] private GameObject controls;

    public void Graphic_Button()
    {
        graphic.SetActive(true);
        audioButton.SetActive(false);
        controls.SetActive(false);
    }
    public void Audio_Button()
    {
        graphic.SetActive(false);
        audioButton.SetActive(true);
        controls.SetActive(false);
    }
    public void Controls_Button()
    {
        graphic.SetActive(false);
        audioButton.SetActive(false);
        controls.SetActive(true);
    }
}
