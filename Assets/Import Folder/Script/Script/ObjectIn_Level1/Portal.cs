using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private static int numberEnemyIsKilled = 0;
    private int numberEnemyKilled = 100;
    [SerializeField] private GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        portal.SetActive(false);
        numberEnemyIsKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(numberEnemyIsKilled==numberEnemyKilled)
        {
            OpenPortal();
        }
    }

    private void OpenPortal()
    {
        portal.SetActive(true);
    }

    static public void KillEnemy()
    {
        numberEnemyIsKilled++;
    }
}
