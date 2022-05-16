using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializationPlayer : MonoBehaviour
{
    private static string fileName="";
    public void SerializationProfil()
    {
        SerializateSlotGameInformation information = new SerializateSlotGameInformation();
        information.blueEssenceValue = GameInformation.GetEssence().blueEssenceValue;
        information.greenEssenceValue = GameInformation.GetEssence().greenEssenceValue;
        information.unlockedElements = GameInformation.GetUnlockElementList();
        SerializationFunction.SaveJson(information, fileName);
    }
    public static void SetFileName(string fileName)
    {
        SerializationPlayer.fileName = fileName;
    }

}
