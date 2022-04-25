using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawnBuff : MonoBehaviour
{
    [SerializeField] private List<GameObject> buffDropList = new List<GameObject>();
    public void SpawnBuff()
    {
        Instantiate<GameObject>(this.buffDropList[Random.Range(0, buffDropList.Count)],this.transform.position+new Vector3(0f,10f,0f),this.transform.rotation);
    }
}
