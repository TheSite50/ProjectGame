using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class ShowInformation : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private TMP_Text informationCanvas;
    [SerializeField] private string itemName;
    private string defoultName = "EMPTY";

    // private void SetScriptableObject(DataObject date)
    //{

    // }

    public void OnPointerEnter(PointerEventData eventData)
    {
        informationCanvas.SetText(itemName);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        informationCanvas.SetText(defoultName);
    }
}
