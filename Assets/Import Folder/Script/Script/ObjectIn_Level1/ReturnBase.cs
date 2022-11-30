using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReturnBase : MonoBehaviour
{
    [SerializeField] private Button backToBase;
    [SerializeField] private int price=5;
    // Update is called once per frame
    void Update()
    {
        if(backToBase.gameObject.activeInHierarchy)
        {
            if(Keyboard.current.eKey.IsPressed())
            {
                BuyTicketReturn();
                
                LoadLevel.SetNextLevel(1);
                SceneManager.LoadScene(2);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        backToBase.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        backToBase.gameObject.SetActive(false);
    }

    void BuyTicketReturn()
    {
        if (GameInformation.GetEssence().blueEssenceValue - price >= 0)
        {
            GameInformation.AddEssence(-price, 0);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
            
    }

}
