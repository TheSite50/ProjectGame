using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Panel_Menage : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject panelGraphic;
    [SerializeField] private GameObject panelAudio;
    [SerializeField] private GameObject panelControll;

    [SerializeField] private Dropdown resolution;
    [SerializeField] private Toggle windowMode;
    [SerializeField] private Dropdown frameRate;
    [SerializeField] private Toggle verticalSync;
    [SerializeField] private Slider brightness;
    [SerializeField] private Dropdown graphicQuality;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider voiceSlider;
    [SerializeField] private Slider effectSlider;



    [SerializeField] private InputActionAsset myInputActionAsset;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private const string RebindsKey = "rebinds";
    public void MainMenu_Button()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
    }
    public void Reset_Button()
    {
        if( panelGraphic.activeInHierarchy == true)
        {
            resolution.value = SaveOptions.ResetOptions().resolution;
            windowMode.isOn = SaveOptions.ResetOptions().windowMode;
            frameRate.value = SaveOptions.ResetOptions().frameRate;
            verticalSync.isOn = SaveOptions.ResetOptions().verticalSync;
            brightness.value = SaveOptions.ResetOptions().brightness;
            graphicQuality.value = SaveOptions.ResetOptions().graphicQuality;
        }
        if( panelAudio.activeInHierarchy == true)
        {
            musicSlider.value = SaveOptions.ResetOptions().music;
            voiceSlider.value = SaveOptions.ResetOptions().voice;
            effectSlider.value = SaveOptions.ResetOptions().effect;
        }
        if (panelControll.activeInHierarchy == true)
        {
            //ApplyBindingOverride
            myInputActionAsset.FindAction("Move").ApplyBindingOverride(2, SaveOptions.ResetOptions().forward);
            myInputActionAsset.FindAction("Move").ApplyBindingOverride(4, SaveOptions.ResetOptions().backwards);
            myInputActionAsset.FindAction("Move").ApplyBindingOverride(6, SaveOptions.ResetOptions().left);
            myInputActionAsset.FindAction("Move").ApplyBindingOverride(8, SaveOptions.ResetOptions().right);
            myInputActionAsset.FindAction("Stomp").ApplyBindingOverride(0, SaveOptions.ResetOptions().skill);
            myInputActionAsset.FindAction("Shoot").ApplyBindingOverride(0, SaveOptions.ResetOptions().shotRightWeapon);
            myInputActionAsset.FindAction("ShootRPM").ApplyBindingOverride(0, SaveOptions.ResetOptions().shotLeftWeapon);
            myInputActionAsset.FindAction("Reload").ApplyBindingOverride(0, SaveOptions.ResetOptions().reload);
        }
    }
    public void Apply_Button()
    {
        ParemeterSaveOptions saveOptions = new ParemeterSaveOptions();
        saveOptions.resolution = resolution.value;
        saveOptions.windowMode = windowMode.isOn;
        saveOptions.frameRate = frameRate.value;
        saveOptions.verticalSync = verticalSync.isOn;
        saveOptions.brightness = brightness.value;
        saveOptions.graphicQuality = graphicQuality.value;


        saveOptions.music = musicSlider.value;
        saveOptions.voice = voiceSlider.value;
        saveOptions.effect = effectSlider.value;



        saveOptions.forward = myInputActionAsset.FindAction("Move").bindings[2].effectivePath;
        saveOptions.backwards = myInputActionAsset.FindAction("Move").bindings[4].effectivePath;
        saveOptions.left = myInputActionAsset.FindAction("Move").bindings[6].effectivePath;
        saveOptions.right = myInputActionAsset.FindAction("Move").bindings[8].effectivePath;
        saveOptions.skill = myInputActionAsset.FindAction("Stomp").bindings[0].effectivePath;
        saveOptions.reload = myInputActionAsset.FindAction("Reload").bindings[0].effectivePath;
        saveOptions.shotLeftWeapon = myInputActionAsset.FindAction("ShootRPM").bindings[0].effectivePath;
        saveOptions.shotRightWeapon = myInputActionAsset.FindAction("Shoot").bindings[0].effectivePath;


        SaveOptions.SaveParameterOptions(saveOptions);
        //SaveOptions.LoadOptions().resolution
        
    }

    public void SetParameter()
    {
        resolution.value = SaveOptions.LoadOptions().resolution;
        windowMode.isOn = SaveOptions.LoadOptions().windowMode;
        frameRate.value = SaveOptions.LoadOptions().frameRate;
        verticalSync.isOn = SaveOptions.LoadOptions().verticalSync;
        brightness.value = SaveOptions.LoadOptions().brightness;
        graphicQuality.value = SaveOptions.LoadOptions().graphicQuality;

        musicSlider.value = SaveOptions.LoadOptions().music;
        voiceSlider.value = SaveOptions.LoadOptions().voice;
        effectSlider.value = SaveOptions.LoadOptions().effect;

        //ApplyBindingOverride
        myInputActionAsset.FindAction("Move").ApplyBindingOverride(2, SaveOptions.LoadOptions().forward);
        myInputActionAsset.FindAction("Move").ApplyBindingOverride(4, SaveOptions.LoadOptions().backwards);
        myInputActionAsset.FindAction("Move").ApplyBindingOverride(6, SaveOptions.LoadOptions().left);
        myInputActionAsset.FindAction("Move").ApplyBindingOverride(8, SaveOptions.LoadOptions().right);
        myInputActionAsset.FindAction("Stomp").ApplyBindingOverride(0, SaveOptions.LoadOptions().skill);
        myInputActionAsset.FindAction("Shoot").ApplyBindingOverride(0, SaveOptions.LoadOptions().shotRightWeapon);
        myInputActionAsset.FindAction("ShootRPM").ApplyBindingOverride(0, SaveOptions.LoadOptions().shotLeftWeapon);
        myInputActionAsset.FindAction("Reload").ApplyBindingOverride(0, SaveOptions.LoadOptions().reload);


        resolution.RefreshShownValue();
        resolution.RefreshShownValue();
        frameRate.RefreshShownValue();
        graphicQuality.RefreshShownValue();

        //SaveOptions.LoadOptions().resolution
        // myInputActionAsset.FindAction("Move").ChangeBinding(1)
        // .WithPath("<Keyboard>/upArrow")
        // .WithPath("<Keyboard>/w")//+ SaveOptions.LoadOptions().forward)
        // .WithPath("<Keyboard>/downArrow")
        // .WithPath("<Keyboard>/s")//+ SaveOptions.LoadOptions().backwards)
        // .WithPath("<Keyboard>/leftArrow")
        // .WithPath("<Keyboard>/a")//+ SaveOptions.LoadOptions().left)
        // .WithPath("<Keyboard>/rightArrow")
        // .WithPath("<Keyboard>/d")//+ SaveOptions.LoadOptions().right);
        // //myInputActionAsset.FindAction("Move").Enable();
        // ;
        // myInputActionAsset.FindAction("Move").Enable();
    }
    //public void ExperimentalCode3(int index)
    //{

    //var accelerateAction = new InputAction("2DVector");
    //accelerateAction.


    //.With("Up", "<Keyboard>/" + SaveOptions.LoadOptions().forward)
    //.With("Down", "<Keyboard>/" + SaveOptions.LoadOptions().backwards)
    //.With("Left", "<Keyboard>/" + SaveOptions.LoadOptions().left)
    //.With("Right", "<Keyboard>/" + SaveOptions.LoadOptions().right);


    //    myAction.AddCompositeBinding("2DVector") // Or "Dpad"
    //.With("Up", "<Keyboard>/w")
    //.With("Down", "<Keyboard>/s")
    //.With("Left", "<Keyboard>/a")
    //.With("Right", "<Keyboard>/d");
    //rebindingOperation = accelerateAction.PerformInteractiveRebinding()
    //         .WithTargetBinding(index)
    //         .OnMatchWaitForAnother(0.1f)
    //         .OnComplete(operation =>
    //         {
    //             changeKey.SetActive(false);
    //             rebindingOperation.Dispose();
    //             myInputActionAsset.FindAction(actionName).Enable();
    //         })
    //         .Start();
    //}


}
