using UnityEngine;
using UnityEngine.EventSystems;

public class SlotGetObject : MonoBehaviour, IDropHandler
{
    private GetAndDragItem slotItem;
    [SerializeField] private ItemType itemType;
    [SerializeField] private GameObject buildField;
    [SerializeField] private bool isRightWeapon = false;
    
    private GameObject spawnObject;
    private void Update()
    {
        if(slotItem==null)
        {
            if (spawnObject != null)
            {
                Destroy(spawnObject);
                SetEmptySlot(itemType,isRightWeapon);
            }
        }
    }
    

    public void OnDrop(PointerEventData eventData)
    {
        slotItem = GetAndDragItem.GetObjectComponent();
        if (slotItem.CompareObject(itemType))
        {
            slotItem.ObjectInSlot(true);
            AddItemToSlot();
        }
        else
        {
            slotItem.ObjectInSlot(false); 
        }
    }

    private void AddItemToSlot()
    {
        if (this.transform.childCount > 0)
        {
            Destroy(this.transform.GetChild(0).gameObject);

        }
        else
        {
            slotItem.transform.SetParent(this.transform, true);
            slotItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.5f, 0.5f);
            RespawnSlotItem.RespawnItem(ref spawnObject, ref buildField, itemType, slotItem, isRightWeapon);
        }
    }
    private void SetEmptySlot(ItemType itemType, bool isRigtWeapon)
    {
        switch (itemType)
        {
            case ItemType.Weapon:
                if (isRigtWeapon)
                {
                    PlayerBuild.AddWeaponRight(null);
                }
                else
                {
                    PlayerBuild.AddWeaponLeft(null);
                }
                break;
            case ItemType.Accessories:
                PlayerBuild.AddAccesories(null);
                break;
            case ItemType.Hands:
                PlayerBuild.AddArm(null);
                break;
            case ItemType.Torso:
                PlayerBuild.AddTorso(null);
                break;
            case ItemType.Legs:
                PlayerBuild.AddLegs(null);
                //SaveBuildField[0] = spawnObject.GetComponent<MechElement>().GetFieldConect(0);

                //SaveBuildField = SpawnObject.transform.GetChild(0).gameObject;
                break;
            default:
                break;
        }
    }
    
}
