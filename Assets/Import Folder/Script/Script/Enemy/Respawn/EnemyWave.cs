using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private int numEnemy;
    [SerializeField] private int numWaveEnemy;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject player;
    private bool canSpawnEnemy = true;
    private void Awake()
    {
        StartCoroutine(SpawnEnemy());
    }
    private void Update()
    {
        if(Portal.GetKillEnemy()==numEnemy&&canSpawnEnemy==true)
        {
            SpawnEnemy();
            canSpawnEnemy = false;
        }
        else if(Portal.GetKillEnemy() == numEnemy*2 && canSpawnEnemy == true)
        {
            SpawnEnemy();
            canSpawnEnemy = false;
        }
        else
        {
            canSpawnEnemy = true;
        }
    }

    private IEnumerator SpawnEnemy()
    {
        int spawnEnemy = 0;
        float spawnLocationX = 0;
        float spawnLocationZ = 0;
        
        while (spawnEnemy < numEnemy)
        {

            spawnLocationX =  this.gameObject.transform.position.x;
            spawnLocationZ = this.gameObject.transform.position.z;
            GameObject spwanedEnemy = Instantiate<GameObject>(enemy[Random.Range(0, enemy.Length)], new Vector3(spawnLocationX, this.gameObject.transform.position.y, spawnLocationZ), this.gameObject.transform.rotation);
            spwanedEnemy.GetComponent<EnemyAction>().SetPlayer(player);
            yield return null;
            spawnEnemy++;
        }
    }
}
