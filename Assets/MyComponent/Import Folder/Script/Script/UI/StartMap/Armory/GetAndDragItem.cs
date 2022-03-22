using UnityEngine;
using UnityEngine.EventSystems;

public class GetAndDragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    static private GetAndDragItem objectComponent;
    static private bool isInSlot = false;

    [SerializeField] private GameObject objectPrefab;

    [SerializeField] private ItemType itemType;

    private bool parentTagSlot = false;


    public void OnBeginDrag(PointerEventData eventData)
    {
        parentTagSlot = this.transform.parent.tag != "Slot" ? true : false;
        if (parentTagSlot)
        {
            objectComponent = Instantiate<GetAndDragItem>(this, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform.parent);
        }
        isInSlot = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (parentTagSlot)
        {
            objectComponent.transform.position = Input.mousePosition;
        }
        else
        {
            this.transform.position = Input.mousePosition;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (parentTagSlot)
        {
            if (isInSlot == false)
            {
                Destroy(objectComponent.gameObject);

            }
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    static public GetAndDragItem GetObjectComponent()
    {
        return objectComponent;
    }

    public bool CompareObject(ItemType itemType)
    {
        return this.itemType == itemType;
    }
    public void ObjectInSlot(bool value)
    {
        isInSlot = value;
    }
    public GameObject ObjectPrefab()
    {
        return objectPrefab;
    }

}