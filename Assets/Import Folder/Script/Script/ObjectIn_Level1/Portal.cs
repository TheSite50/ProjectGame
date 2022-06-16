using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Portal : MonoBehaviour
{
    private static float numberEnemyIsKilled = 0;
    private static int numberEnemyKilled = 15;
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject run;
    [SerializeField] private GameObject run2;
    // Start is called before the first frame update
    void Start()
    {
        portal.SetActive(false);
        numberEnemyIsKilled =0;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberEnemyIsKilled == numberEnemyKilled)
        {
            OpenPortal();
        }
        run.GetComponent<MeshRenderer>().material.SetFloat("_Progress", (float)(numberEnemyIsKilled/numberEnemyKilled) * 2);
        run2.GetComponent<MeshRenderer>().material.SetFloat("_Progress", (float)(numberEnemyIsKilled / numberEnemyKilled) * 2);
    }

    private void OpenPortal()
    {
        portal.SetActive(true);
    }
    
    static public void KillEnemy()
    {
        numberEnemyIsKilled++;
    }
    static public float GetKillEnemy()
    {
        return numberEnemyIsKilled;
    }
    static public void numberEnemySpawn(int value)
    {
        numberEnemyKilled = value;
    }
}
