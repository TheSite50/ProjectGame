using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.InputSystem;

public class GetAndDragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    static private GetAndDragItem objectComponent;
    static private bool isInSlot = false;

    [SerializeField] private GameObject objectPrefab; 

    [SerializeField] private ItemType itemType;
    static private bool leftWeapon = false;
    private bool parentTagSlot = false;
    private bool isUnlock = false;

    private void Update()
    {
        if(!this.gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            isUnlock=true;
        }
        else
        {
            isUnlock = false;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isUnlock)
            return;
            parentTagSlot = this.transform.parent.tag != "Slot" ? true : false;
            if (parentTagSlot)
            {
                objectComponent = Instantiate<GetAndDragItem>(this, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform.parent);
            }
            isInSlot = false;
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!isUnlock)
            return;
        if (parentTagSlot)
            {
            objectComponent.transform.position = Mouse.current.position.ReadValue();
        }
            else
            {
                this.transform.position = Mouse.current.position.ReadValue();
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isUnlock)
            return;
        if (parentTagSlot)
        { 
            if (isInSlot==false)
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
    public bool GetWeaponPosition()
    {
        return leftWeapon;
    }
}
