using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour
{
    private static int blueEssenceValue=200;
    private static int greenEssenceValue=50;
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    public static (int blueEssenceValue, int greenEssenceValue) GetEssence()
    {
        return (blueEssenceValue, greenEssenceValue);
    }

    public static void SetEssence(int addBlueEsssence,int addGreenEssence)
    {
        blueEssenceValue += addBlueEsssence;
        greenEssenceValue += addGreenEssence;
    }
}
