using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Graphic : MonoBehaviour
{
    [SerializeField]private Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private void Awake()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            options.Add(option); 

            if(resolutions[i].width == Screen.currentResolution.width&&resolutions[i].height==Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }
    public void SetWindowMode(bool windowMode)
    {
        Screen.fullScreen = windowMode;
    }
    public void SetFrameRate()
    {

    }
    public void SetVerticalSync()
    {

    }
    public void SetBrightness()
    {

    }
    public void SetGraphicQuality(int graphicQualityLevel)
    {
        QualitySettings.SetQualityLevel(graphicQualityLevel);
    }

}
