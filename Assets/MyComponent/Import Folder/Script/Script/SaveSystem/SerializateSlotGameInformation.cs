using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;
[Serializable]
public class SerializateSlotGameInformation 
{
    public int blueEssenceValue=100;
    public int greenEssenceValue=20;
    public List<bool> unlockedElements=new List<bool>();
}
