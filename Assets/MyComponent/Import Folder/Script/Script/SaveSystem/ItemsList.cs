using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    [SerializeField] private List<GameObject> mechComponentList = new List<GameObject>();
    List<bool> list = new List<bool>();
    private void Start()
    {
        if (GameInformation.GetUnlockElementList().Count > 0)
        {
            for (int i = 0; i < mechComponentList.Count; i++)
            {
                mechComponentList[i].GetComponent<GetAndDragItem>().SetIsUnlock(GameInformation.GetUnlockElementList()[i]);
                
            }
        }
        for (int i = 0; i < mechComponentList.Count; i++)
        {
            list.Add(mechComponentList[i].GetComponent<GetAndDragItem>().GetIsUnlock());
        }
    }
    private void Update()
    {
        UpdateListInformation();
    }
    private void UpdateListInformation()
    {
        for(int i = 0; i<mechComponentList.Count; i++)
        {
            if (list[i] != mechComponentList[i].GetComponent<GetAndDragItem>().GetIsUnlock())
            {
                list[i] = mechComponentList[i].GetComponent<GetAndDragItem>().GetIsUnlock();
            }
        }
        GameInformation.SetElementsList(list);
    }
    //public void UpdateMyInformation()
    //{
    //    
    //}
}
