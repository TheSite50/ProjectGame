using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class ShowInformation : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private TMP_Text informationCanvas;
    [SerializeField] private TMP_Text price;
    [SerializeField] private string itemName;
    private string defoultName = "EMPTY";

    

    public void OnPointerEnter(PointerEventData eventData)
    {
        informationCanvas.SetText(itemName);
        if(this.GetComponent<Button>().enabled == false)
        {
            price.SetText("0");
        }
        else
        {
            price.SetText(this.GetComponent<BuyComponent>().GetPrice().ToString());
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        informationCanvas.SetText(defoultName);
        price.SetText("----------");
    }
}
