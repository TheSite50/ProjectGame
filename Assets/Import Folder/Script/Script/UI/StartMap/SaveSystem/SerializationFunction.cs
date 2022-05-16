
using UnityEngine;
using System.IO;
public static class SerializationFunction 
{
    //static string path = Application.persistentDataPath;
    //static string fileName = "/Player.txt";
    


    public static void SaveJson(SerializateSlotGameInformation data,string path)
    {
        string jsonFille = JsonUtility.ToJson(data);
        File.WriteAllText(path, jsonFille);
        
    }
    public static void LoadJson( ref SerializateSlotGameInformation data, string path)
    {

        //Debug.Log("*" + File.ReadAllText(path).ToString() + "*");
        //if (File.Exists(path))
        //{
            //Debug.Log("*"+File.ReadAllText(path).ToString()+"*");
            //if (File.ReadAllText(path).ToString() != "")
            //{
                string jsonS = File.ReadAllText(path).ToString();
                data = JsonUtility.FromJson<SerializateSlotGameInformation>(jsonS);
            //}

            
        //}
        //if (File.Exists(Application.persistentDataPath + "/MenageSave.JSON"))
        //{
        //    string jsonS = File.ReadAllText(Application.persistentDataPath + "/MenageSave.JSON");
        //    data = JsonUtility.FromJson<SerializateDataMenage>(jsonS);
        //}
        //else
        //{
        //    Debug.Log("Error dont Exist this file");
        //}
        
    }

}
