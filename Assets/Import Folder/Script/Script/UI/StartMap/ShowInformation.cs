using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class ShowInformation : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private TMP_Text informationCanvas;
    [SerializeField] private TMP_Text parameterCanvas;
    [SerializeField] private TMP_Text descriptionCanvas;
    [SerializeField] private TMP_Text price;
    [SerializeField] private string itemName;
    [SerializeField] private string parameters;
    [SerializeField] private string description;
    private string defaultName = "Nothing";
    private string defaultParameters = "To select an item";
    private string defaultDescription = "Hover on it";



    public void OnPointerEnter(PointerEventData eventData)
    {
        informationCanvas.SetText(itemName);
        parameterCanvas.SetText(parameters);
        descriptionCanvas.SetText(description);
        if (this.GetComponent<Button>().enabled == false)
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
        informationCanvas.SetText(defaultName);
        parameterCanvas.SetText(defaultParameters);
        descriptionCanvas.SetText(defaultDescription);
        price.SetText("0");
    }
}
