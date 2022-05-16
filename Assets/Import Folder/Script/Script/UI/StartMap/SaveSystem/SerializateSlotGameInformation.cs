using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;
[Serializable]
public class SerializateSlotGameInformation 
{
    public int blueEssenceValue=200;
    public int greenEssenceValue=0;
    public List<bool> unlockedElements=new List<bool>();
}
