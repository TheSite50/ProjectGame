using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class ButtonControll : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI textKey;
    //[SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private InputActionAsset myInputActionAssets;
    [SerializeField] private string keyName = "";
    private string keySendName = "";
    //public (Button button, TextMeshProUGUI textKey, TextMeshProUGUI textName) SendInformation()
    //{
    //    return (button, textKey, textName);
    //}
    public string SendInformation()
    {
        if (keyName == "Up")
        {
            keySendName = "Move";
        }
        else if (keyName == "Down")
        {
            keySendName = "Move";
        }
        else if (keyName == "Left")
        {
            keySendName = "Move";
        }
        else if (keyName == "Right")
        {
            keySendName = "Move";
        }
        else
        {
            keySendName = keyName;
        }

        return keySendName;
    }
    private void Update()
    {
        if (keyName == "Up")
        {
             this.textKey.text = InputControlPath.ToHumanReadableString(
             myInputActionAssets.FindAction("Move").bindings[2].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        }
        if (keyName == "Down")
        {
            this.textKey.text = InputControlPath.ToHumanReadableString(
            myInputActionAssets.FindAction("Move").bindings[4].effectivePath,
           InputControlPath.HumanReadableStringOptions.OmitDevice);
        }
        if (keyName == "Left")
        {
            this.textKey.text = InputControlPath.ToHumanReadableString(
            myInputActionAssets.FindAction("Move").bindings[6].effectivePath,
           InputControlPath.HumanReadableStringOptions.OmitDevice);
        }
        if (keyName == "Right")
        {
            this.textKey.text = InputControlPath.ToHumanReadableString(
            myInputActionAssets.FindAction("Move").bindings[8].effectivePath,
           InputControlPath.HumanReadableStringOptions.OmitDevice);
        }
        if (keyName == "Stomp")
        {
            this.textKey.text = InputControlPath.ToHumanReadableString(
          myInputActionAssets.FindAction(keyName).bindings[0].effectivePath,
           InputControlPath.HumanReadableStringOptions.OmitDevice);
        }
        if (keyName == "ShootRPM")
        {
            this.textKey.text = InputControlPath.ToHumanReadableString(
          myInputActionAssets.FindAction(keyName).bindings[0].effectivePath,
           InputControlPath.HumanReadableStringOptions.OmitDevice);
        }
        if (keyName == "Shoot")
        {
            this.textKey.text = InputControlPath.ToHumanReadableString(
          myInputActionAssets.FindAction(keyName).bindings[1].effectivePath,
           InputControlPath.HumanReadableStringOptions.OmitDevice);
        }
        if (keyName == "Reload")
        {
            this.textKey.text = InputControlPath.ToHumanReadableString(
            myInputActionAssets.FindAction(keyName).bindings[0].effectivePath,
           InputControlPath.HumanReadableStringOptions.OmitDevice);
        }
    }
}
