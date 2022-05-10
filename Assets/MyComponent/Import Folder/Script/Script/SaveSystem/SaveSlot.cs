
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class SaveSlot : MonoBehaviour
{
    [SerializeField] private Button createSave;
    [SerializeField] private Button delateSave;
    [SerializeField] private TMP_InputField playerName;
    [SerializeField] private int slotNumber=0;
    SerializateDataMenage serializateData = new SerializateDataMenage();
    
    void Start()
    {
        if (slotNumber == 1&&SaveMenagment.LoadJson().firstSlotName!="")
        {
            playerName.text = SaveMenagment.LoadJson().firstSlotName;
            createSave.gameObject.SetActive(false);
            gameObject.GetComponent<Button>().interactable = true;
            delateSave.gameObject.SetActive(true);
        }
        else if (slotNumber == 2 && SaveMenagment.LoadJson().secondSlotName != "")
        {
            playerName.text = SaveMenagment.LoadJson().secondSlotName;
            createSave.gameObject.SetActive(false);
            gameObject.GetComponent<Button>().interactable = true;
            delateSave.gameObject.SetActive(true);
        }
        else if (slotNumber == 3 && SaveMenagment.LoadJson().thirtySlotName != "")
        {
            playerName.text = SaveMenagment.LoadJson().thirtySlotName;
            createSave.gameObject.SetActive(false); 
            gameObject.GetComponent<Button>().interactable = true;
            delateSave.gameObject.SetActive(true);
        }
    }
  
    public void CreateSlotSave()
    {
        serializateData = SaveMenagment.LoadJson();

        if (slotNumber == 1)
        {
            serializateData.firstSlotName = playerName.text;
        }
        else if (slotNumber == 2)
        {
            serializateData.secondSlotName = playerName.text;
        }
        else if (slotNumber == 3)
        {
            serializateData.thirtySlotName = playerName.text;
        }
        createSave.gameObject.SetActive(false);
        gameObject.GetComponent<Button>().interactable = true;
        playerName.interactable = false;
        delateSave.gameObject.SetActive(true);
        SaveMenagment.SerializationMenagmentSlot(serializateData);
        File.Create(Application.persistentDataPath + "/" + playerName.text + ".JSON");
    }

    public void DelateSlotSave()
    {
        File.Delete(Application.persistentDataPath + "/" + playerName.text + ".JSON");
        serializateData = SaveMenagment.LoadJson();
        playerName.text = "";
        if (slotNumber == 1)
        {
            serializateData.firstSlotName = playerName.text;
        }
        else if (slotNumber == 2)
        {
            serializateData.secondSlotName = playerName.text;
        }
        else if (slotNumber == 3)
        {
            serializateData.thirtySlotName = playerName.text;
        }
        SaveMenagment.SerializationMenagmentSlot(serializateData);

        createSave.gameObject.SetActive(true);
        playerName.interactable = true;
        
        gameObject.GetComponent<Button>().interactable = false;
        delateSave.gameObject.SetActive(false);
        
    }

    public string GetSerializationData()
    {
        serializateData = SaveMenagment.LoadJson();
        if (slotNumber==1)
        {
            return serializateData.firstSlotName ;

        }
        else if (slotNumber == 2)
        {
            return serializateData.secondSlotName ;
        }
        else if (slotNumber == 3)
        {
            return serializateData.thirtySlotName ;
        }
        return "";
    }
}
