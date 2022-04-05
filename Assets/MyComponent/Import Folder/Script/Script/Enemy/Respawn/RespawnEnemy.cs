using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    [SerializeField] private int numEnemy;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    private void Awake()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        int spawnEnemy = 0;
        float spawnLocationX = 0;
        float spawnLocationZ = 0;
        
        while (spawnEnemy<numEnemy)
        {
            
            spawnLocationX = Random.Range(this.gameObject.transform.position.x - 1000, this.gameObject.transform.position.x + 1000);
            spawnLocationZ = Random.Range(this.gameObject.transform.position.z - 1000, this.gameObject.transform.position.z + 1000);
            GameObject spwanedEnemy= Instantiate<GameObject>(enemy, new Vector3(spawnLocationX, this.gameObject.transform.position.y, spawnLocationZ),this.gameObject.transform.rotation);
            spwanedEnemy.GetComponent<EnemyAction>().SetPlayer(player);
            yield return null;
            spawnEnemy++;
        }

        
    }
}
