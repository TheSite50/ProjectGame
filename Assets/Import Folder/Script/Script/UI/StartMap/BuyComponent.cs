using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyComponent : MonoBehaviour
{
    [SerializeField] private int price = 20;

    public void BuyThisCompoennt()
    {
        if(GameInformation.GetEssence().blueEssenceValue-price>=0)
        {
            GameInformation.AddEssence(-price, 0);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.GetComponent<Button>().enabled = false;
            //if(this.gameObject.GetComponent<InformationAboutMe>())
            //{
            //    this.gameObject.GetComponent<InformationAboutMe>().SendIngormationAboutMe();
            //}
        }
    }
    public int GetPrice()
    {
        return this.price;
    }
}
