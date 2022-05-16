using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ShowInformation : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private Image informationCanvas;

    public void OnPointerEnter(PointerEventData eventData)
    {
        informationCanvas.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        informationCanvas.gameObject.SetActive(false);
    }
}
