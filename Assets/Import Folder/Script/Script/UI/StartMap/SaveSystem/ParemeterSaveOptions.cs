using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;
[Serializable]
public class ParemeterSaveOptions 
{
    //Graphic
    public int resolution = 1;
    public bool windowMode = true;
    public int frameRate = 1;
    public bool verticalSync = true;
    public float brightness = 1;
    public int graphicQuality = 1;

    //Audio
    public float music = 1;
    public float voice = 1;
    public float effect = 1;

    //Controls
    public string forward = "W";
    public string backwards = "S";
    public string left = "A";
    public string right = "D";
    public string skill = "Q";
    public string reload = "E";
    public string shotLeftWeapon = "LeftButton";
    public string shotRightWeapon = "RightButton";

}

