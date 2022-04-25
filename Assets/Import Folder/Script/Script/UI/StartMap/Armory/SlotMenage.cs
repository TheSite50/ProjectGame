using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMenage : MonoBehaviour
{
    [SerializeField] private GameObject[] nextSlotOpen;
    //Do Poprawy Niepotrzeba Update
    private void Update()
    {
        if(this.gameObject.transform.childCount>0)
        {
            foreach(GameObject slotOpen in nextSlotOpen)
            {
                slotOpen.GetComponent<Image>().enabled = true;
                slotOpen.GetComponent<SlotGetObject>().enabled = true;
            }
        }
        if (this.gameObject.transform.childCount == 0)
        {
            foreach (GameObject slotOpen in nextSlotOpen)
            {
                slotOpen.GetComponent<Image>().enabled = false;
                slotOpen.GetComponent<SlotGetObject>().enabled = false;
            }
        }
    }
}
