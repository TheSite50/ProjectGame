using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public SlotInfo przedmiot;
    public Image image;

    public void DodajPrzedmiot(SlotInfo slotInfo)
    {
        przedmiot = slotInfo;
        image.sprite = slotInfo.ikonaPrzedmiotu;
        image.gameObject.SetActive(true);
    }
}
