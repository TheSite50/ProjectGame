using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{
    [SerializeField] private List<int> numEnemyInWave = new List<int>();
    [SerializeField] private List<GameObject> enamyTyp = new List<GameObject>();
    [SerializeField] private List<GameObject> spawnPoints = new List<GameObject>();
    private int numWave=0;
    private GameObject spawnPoint;
    private int randomValue=0;
    private GameObject player;
    private int value = 0;
    private void Awake()
    {
        
        
       
        
    }
    private void Start()
    {
        player = PlayerStats.SendPlayer();
        SpawnNewEnemy();
        foreach (int num in numEnemyInWave)
        {
            value += num;
        }
        Portal.numberEnemySpawn(value);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Portal.GetKillEnemy() == Sum(numWave))
        {
            numWave++;
            SpawnNewEnemy();
        }

    }
    private void SpawnNewEnemy()
    {
        randomValue = Random.Range(0, spawnPoints.Count);
        spawnPoint = spawnPoints[randomValue];
        if (Vector3.Distance(player.gameObject.transform.position, spawnPoint.gameObject.transform.position) <= 900)
        {
            if((Vector3.Distance(player.gameObject.transform.position, spawnPoints[randomValue + 1].gameObject.transform.position) <= 900))
            {
                spawnPoint = randomValue + 2 > spawnPoints.Count ? spawnPoints[0] : spawnPoints[randomValue + 2];
            }
            spawnPoint = randomValue + 1 > spawnPoints.Count ? spawnPoints[0] : spawnPoints[randomValue + 1];
        }

        StartCoroutine(SpawnEnemy(numEnemyInWave[numWave], enamyTyp, spawnPoint.transform.position));
    }
    private int Sum(int number = 10 )
    {
        int value = 0;
        int meter = 0;
        foreach (int num in numEnemyInWave)
        {
            value += num;
            if (meter == number)
            {
                return value;
            }
            else
            {
                meter++;
            }
        }
        return 0;
    }




    public IEnumerator SpawnEnemy(int numEnemy, List<GameObject> enemy, Vector3 position)
    {
        int spawnEnemy = 0;
        float spawnLocationX = 0;
        float spawnLocationZ = 0;

        while (spawnEnemy < numEnemy)
        {

            spawnLocationX = position.x;
            spawnLocationZ = position.z;
            GameObject spwanedEnemy = Instantiate<GameObject>(enemy[Random.Range(0, enemy.Count)], new Vector3(spawnLocationX, position.y, spawnLocationZ), this.gameObject.transform.rotation);
            spwanedEnemy.GetComponent<EnemyAction>().SetPlayer(player);
            yield return null;
            spawnEnemy++;
        }
    }
}
