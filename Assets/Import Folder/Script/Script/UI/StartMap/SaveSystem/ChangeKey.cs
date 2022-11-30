using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class ChangeKey : MonoBehaviour
{
    [SerializeField] private GameObject changeKey;
    [SerializeField] private InputActionAsset myInputActionAsset;



    //[SerializeField] private InputActionReference myInputActionReference;
    private ButtonControll buttonController;
    private string actionName = "";

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private const string RebindsKey = "rebinds";
    public void Change(ButtonControll buttonControll)
    {
        changeKey.SetActive(true);
        buttonController = buttonControll;
        actionName = buttonControll.SendInformation();
    }
    public void ExperimentalCode()
    {
            myInputActionAsset.FindAction(actionName).Disable();
            rebindingOperation = myInputActionAsset.FindAction(actionName).PerformInteractiveRebinding()
                .OnMatchWaitForAnother(0.1f)
                .OnComplete(operation =>
                {
                    changeKey.SetActive(false);
                    rebindingOperation.Dispose();
                    myInputActionAsset.FindAction(actionName).Enable();
                })
                .Start();
    }
    public void ExperimentalCode2(int index)
    {
        myInputActionAsset.FindAction(actionName).Disable();
        rebindingOperation = myInputActionAsset.FindAction(actionName).PerformInteractiveRebinding()
                .WithTargetBinding(index)
                .OnMatchWaitForAnother(0.1f)
                .OnComplete(operation =>
                {
                    changeKey.SetActive(false);
                    rebindingOperation.Dispose();
                    myInputActionAsset.FindAction(actionName).Enable();
                })
                .Start();
    }

}
