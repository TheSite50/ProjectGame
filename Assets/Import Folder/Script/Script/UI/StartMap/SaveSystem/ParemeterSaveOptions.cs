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
    public string forward = "w";
    public string backwards = "s";
    public string left = "a";
    public string right = "d";
    public string skill = "q";
    public string reload = "e";
    public string shotLeftWeapon = "leftButton";
    public string shotRightWeapon = "rightButton";

}

