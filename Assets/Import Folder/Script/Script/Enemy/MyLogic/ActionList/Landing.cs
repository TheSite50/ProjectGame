using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : IAction
{
    private float distanceDetection;
    private float distanceFarAttack;
    private bool attack = true;
    public Landing(float distanceDetection, float distanceFarAttack)
    {
        this.distanceDetection = distanceDetection;
        this.distanceFarAttack = distanceFarAttack;
    }
    public void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction)
    {
       
        enemy.GetComponent<Rigidbody>().useGravity = true;

        StateAction(ActionState.actionRunning, enemyAction);
        

        //if landing
    }

    public void StateAction(ActionState enemyState, EnemyControll enemyAction)
    {
        enemyAction.SetState(enemyState);
    }
}

