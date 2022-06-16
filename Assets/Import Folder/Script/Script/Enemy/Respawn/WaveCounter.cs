using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{
    [SerializeField] private List<int> numEnemyInWave;
    [SerializeField] private List<GameObject> enamyTyp;
    [SerializeField] private List<GameObject> spawnPoints;
    private int numWave=0;
    private GameObject spawnPoint;
    private int randomValue=0;
    private GameObject player;
    private void Awake()
    {
        player = PlayerStats.SendPlayer();
        int value = 0;
        foreach(int num in numEnemyInWave)
        {
            value += num;
        }
        
    }
    private void Start()
    {
        SpawnNewEnemy();
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
        randomValue = Random.Range(0, spawnPoints.Count - 1);
        spawnPoint = spawnPoints[randomValue];
        if (Vector3.Distance(this.gameObject.transform.position, spawnPoint.gameObject.transform.position) <= 1000)
        {
            spawnPoint = randomValue + 1 > spawnPoints.Count - 1 ? spawnPoints[0] : spawnPoints[randomValue + 1];
        }

        StartCoroutine(SpawnEnemy(numEnemyInWave[numWave], enamyTyp));
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




    public IEnumerator SpawnEnemy(int numEnemy, List<GameObject> enemy)
    {
        int spawnEnemy = 0;
        float spawnLocationX = 0;
        float spawnLocationZ = 0;

        while (spawnEnemy < numEnemy)
        {

            spawnLocationX = this.gameObject.transform.position.x;
            spawnLocationZ = this.gameObject.transform.position.z;
            GameObject spwanedEnemy = Instantiate<GameObject>(enemy[Random.Range(0, enemy.Count)], new Vector3(spawnLocationX, this.gameObject.transform.position.y, spawnLocationZ), this.gameObject.transform.rotation);
            spwanedEnemy.GetComponent<EnemyAction>().SetPlayer(player);
            yield return null;
            spawnEnemy++;
        }
    }
}
