using System.Collections;
using System.Text;
using UnityEngine;
using System.IO;

public class SaveMenagment : MonoBehaviour
{
    private void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/MenageSave.JSON"))
        {
            File.Create(Application.persistentDataPath + "/MenageSave.JSON");
        }
    }
    
    public static void SerializationMenagmentSlot(SerializateDataMenage data)
    {
        string jsonFille = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/MenageSave.JSON", jsonFille);
    }

    public static SerializateDataMenage LoadJson()
    {
        SerializateDataMenage data = new SerializateDataMenage();

        if (File.Exists(Application.persistentDataPath + "/MenageSave.JSON"))
        {
            string jsonS = File.ReadAllText(Application.persistentDataPath + "/MenageSave.JSON");
            data = JsonUtility.FromJson<SerializateDataMenage>(jsonS);
        }
        else
        {
            Debug.Log("Error dont Exist this file");
        }
        return data;
    }

    public static SerializateDataMenage GetSerializableData()
    {
        return LoadJson();
    }
}
