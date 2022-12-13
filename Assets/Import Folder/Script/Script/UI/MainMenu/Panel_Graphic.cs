using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Graphic : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionDropdown;


    private List<(int width, int height)> resolutionValueList = new List<(int, int)>();
    //private Resolution[] resolutions;
    private void Awake()
    {
        //resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();


        AddNewResolution(options, 3440, 1440, 0);
        AddNewResolution(options, 2560, 1600, 1);
        AddNewResolution(options, 2560, 1440, 2);
        AddNewResolution(options, 2560, 1080, 3);
        AddNewResolution(options, 2048, 1152, 4);
        AddNewResolution(options, 2048, 1536, 5);
        AddNewResolution(options, 1920, 1200, 6);
        AddNewResolution(options, 1920, 1080, 7);
        AddNewResolution(options, 1680, 1050, 8);
        AddNewResolution(options, 1600, 900, 9);
        AddNewResolution(options, 1536, 864, 10);
        AddNewResolution(options, 1440, 900, 11);
        AddNewResolution(options, 1366, 768, 12);
        AddNewResolution(options, 1360, 768, 13);
        AddNewResolution(options, 1280, 1024, 14);
        AddNewResolution(options, 1280, 800, 15);
        AddNewResolution(options, 1280, 720, 16);
        AddNewResolution(options, 1024, 768, 17);
        AddNewResolution(options, 800, 600, 18);
        AddNewResolution(options, 640, 360, 19);
        AddNewResolution(options, 320, 320, 20);
        //resolutions = options;
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = SaveOptions.LoadOptions().resolution;
        resolutionDropdown.RefreshShownValue();
    }

    private void AddNewResolution(List<string> options,int resolutionWidth,int resolutionHeight,int index)
    {
        options.Add(resolutionWidth+" x "+ resolutionHeight);
        resolutionValueList.Add((resolutionWidth, resolutionHeight));
        
        //if (resolutionWidth == Screen.currentResolution.width && resolutionHeight == Screen.currentResolution.height)
        //{
        //
        //    
        //}
    }

    public void SetResolution(int resolutionValue)
    {
        //Resolution resolution = resolutions[resolutionValue];
        
        Screen.SetResolution(resolutionValueList[resolutionValue].width, resolutionValueList[resolutionValue].height, Screen.fullScreen);
    }
    public void SetWindowMode(bool windowMode)
    {
        Screen.fullScreen = windowMode;
    }
    public void SetFrameRate(int frameRate)
    {
        if(frameRate==0)
        {
            Application.targetFrameRate = 30;
        }
        if (frameRate == 1)
        {
            Application.targetFrameRate = 60;
        }
        if (frameRate == 2)
        {
            Application.targetFrameRate = 120;
        }
        
    }
    public void SetVerticalSync(bool vSync)
    {
        QualitySettings.vSyncCount = vSync==true?1:0;
    }
    public void SetBrightness()
    {

    }
    public void SetGraphicQuality(int graphicQualityLevel)
    {
        QualitySettings.SetQualityLevel(graphicQualityLevel);
    }

}
