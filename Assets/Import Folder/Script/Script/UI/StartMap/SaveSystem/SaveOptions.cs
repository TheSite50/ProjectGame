using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveOptions : MonoBehaviour
{
    [SerializeField] private Panel_Menage saveOptions;
    // Start is called before the first frame update
    void Start()
    {
        //print(Application.persistentDataPath);
        if (!File.Exists(Application.persistentDataPath + "/DefaultSaveOptions.JSON"))
        {
            File.Create(Application.persistentDataPath + "/DefaultSaveOptions.JSON").Dispose();
        }
        if (!File.Exists(Application.persistentDataPath + "/MySaveOptions.JSON"))
        {
            File.Create(Application.persistentDataPath + "/MySaveOptions.JSON").Dispose();
        }
        if (File.ReadAllText(Application.persistentDataPath + "/MySaveOptions.JSON") == "")
        {
            ParemeterSaveOptions data = new ParemeterSaveOptions();
            SerializationOption(data);
        }
        //LoadOptions();
        saveOptions.SetParameter();
    }
    public static void SerializationOption(ParemeterSaveOptions data)
    {
        string jsonFille = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/MySaveOptions.JSON", jsonFille);
    }


    private static ParemeterSaveOptions LoadJson()
    {
        ParemeterSaveOptions data = new ParemeterSaveOptions();

        if (File.Exists(Application.persistentDataPath + "/MySaveOptions.JSON"))
        {
            string jsonS = File.ReadAllText(Application.persistentDataPath + "/MySaveOptions.JSON");
            data = JsonUtility.FromJson<ParemeterSaveOptions>(jsonS);
        }
        else
        {
            Debug.Log("Error dont Exist this file");
        }
        return data;
    }

    public static ParemeterSaveOptions LoadOptions()
    {
        return LoadJson();
    }
    private static ParemeterSaveOptions LoadResetJson()
    {
        ParemeterSaveOptions data = new ParemeterSaveOptions();

        if (File.Exists(Application.persistentDataPath + "/DefaultSaveOptions.JSON"))
        {
            string jsonS = File.ReadAllText(Application.persistentDataPath + "/DefaultSaveOptions.JSON");
            data = JsonUtility.FromJson<ParemeterSaveOptions>(jsonS);
        }
        else
        {
            Debug.Log("Error dont Exist this file");
        }
        return data;
    }
    public static ParemeterSaveOptions ResetOptions()
    {
        return LoadResetJson();
    }

    public static void SaveParameterOptions(ParemeterSaveOptions paremeterSaveOptions)
    {
        ParemeterSaveOptions data = new ParemeterSaveOptions();
        if (File.Exists(Application.persistentDataPath + "/MySaveOptions.JSON"))
        {
            //string jsonS = File.ReadAllText(Application.persistentDataPath + "/MySaveOptions.JSON");
            //data = JsonUtility.FromJson<ParemeterSaveOptions>(jsonS);
            data = paremeterSaveOptions;
            string jsonFille =JsonUtility.ToJson(data);
           // string jsonFille = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/MySaveOptions.JSON", jsonFille);
        }
        else
        {
            Debug.Log("Error dont Exist this file");
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
