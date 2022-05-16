using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour
{
    private static int blueEssenceValue=200;
    private static int greenEssenceValue=0;
    private static List<bool> playerUnlockElements = new List<bool>();
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }

    public static (int blueEssenceValue, int greenEssenceValue) GetEssence()
    {
        return (blueEssenceValue, greenEssenceValue);
    }
    public static void SetElementsList(List<bool> playerElementsList)
    {
        playerUnlockElements = playerElementsList;
    }
    public static List<bool> GetUnlockElementList()
    {
        return playerUnlockElements;
    }

    public static void AddEssence(int addBlueEsssence,int addGreenEssence)
    {
        blueEssenceValue += addBlueEsssence;
        greenEssenceValue += addGreenEssence;
    }
    public static void SetGameInformation(int setBlueEsssence, int setGreenEssence, List<bool> setPlayerUnlockElements)
    {
        blueEssenceValue = setBlueEsssence;
        greenEssenceValue = setGreenEssence;
        playerUnlockElements = setPlayerUnlockElements;
    }

   
}
