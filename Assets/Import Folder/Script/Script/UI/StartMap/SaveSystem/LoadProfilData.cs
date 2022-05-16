using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
public class LoadProfilData: MonoBehaviour
{
    SerializateSlotGameInformation dataFunction = new SerializateSlotGameInformation();
    public void SendInformation()
    {
        SerializationPlayer.SetFileName(Application.persistentDataPath + "/" + GetComponent<SaveSlot>().GetSerializationData() + ".JSON");
        if (File.ReadAllText(Application.persistentDataPath + "/" + GetComponent<SaveSlot>().GetSerializationData() + ".JSON") == "")
        {
            dataFunction = new SerializateSlotGameInformation();
        }
        else
        SerializationFunction.LoadJson(ref dataFunction, Application.persistentDataPath + "/" + GetComponent<SaveSlot>().GetSerializationData() + ".JSON");
        GameInformation.SetGameInformation(dataFunction.blueEssenceValue, dataFunction.greenEssenceValue, dataFunction.unlockedElements);
        
        
        SceneManager.LoadScene(1);
    }
}
