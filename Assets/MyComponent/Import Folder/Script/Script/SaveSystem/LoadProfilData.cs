using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class LoadProfilData: MonoBehaviour
{
    SerializateSlotGameInformation dataFunction = new SerializateSlotGameInformation();
    public void SendInformation()
    {
        SerializationPlayer.SetFileName(Application.persistentDataPath + "/" + GetComponent<SaveSlot>().GetSerializationData() + ".JSON");
        dataFunction= SerializationFunction.LoadJson(dataFunction, Application.persistentDataPath + "/" + GetComponent<SaveSlot>().GetSerializationData() + ".JSON");
        GameInformation.SetGameInformation(dataFunction.blueEssenceValue, dataFunction.greenEssenceValue, dataFunction.unlockedElements);
    }
   
}
