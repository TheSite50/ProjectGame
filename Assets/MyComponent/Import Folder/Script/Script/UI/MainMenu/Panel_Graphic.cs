using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Graphic : MonoBehaviour
{
    private Resolution[] resolutions;
    static float brightness = 0;
    [SerializeField] private Dropdown resolutionDropdown;
    [SerializeField] private Dropdown qualityDropdown;
    [SerializeField] private Dropdown frameRateDropdown;
    [SerializeField] private Slider brightnessSlider;
    private void Start()
    {
        resolutionDropdown.ClearOptions();
        resolutions = Screen.resolutions;
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i=0;i<resolutions.Length;i++)
        {

            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width&& resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        brightness = brightnessSlider.value;
        QualitySettings.maxQueuedFrames = 30;
        QualitySettings.SetQualityLevel(qualityDropdown.value);
        QualitySettings.vSyncCount = 0;
        Screen.fullScreen = true;
    }
    public void SetResolution()
    {
        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetVerticalSync(bool isVerticalSync)
    {
        QualitySettings.vSyncCount = isVerticalSync == true ? 4 : 0;
    }
    public void SetGraphicQuality()
    {
        QualitySettings.SetQualityLevel(qualityDropdown.value);
    }
    public void SetFrameRate()
    {
        QualitySettings.maxQueuedFrames = frameRateDropdown.value == 0 ? 30 : frameRateDropdown.value == 1 ? 60 : 120;
    }
    public void SetBrightness()
    {
        brightness = brightnessSlider.value;
        
    }
    static public float GetBrightness()
    {
        return brightness;
    }
}
