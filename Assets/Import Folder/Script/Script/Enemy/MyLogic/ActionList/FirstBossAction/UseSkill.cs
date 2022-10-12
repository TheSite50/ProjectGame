using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class UseSkill : IAction
{
    private static int useSkill = 0;
    private float distanceFarAttack = 0;
    private float distanceDetection = 0;
    public UseSkill(float distanceFarAttack, float distanceDetection)
    {
        this.distanceFarAttack = distanceFarAttack;
        this.distanceDetection = distanceDetection;
    }

    public void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction)
    {
        enemy.GetComponent<NavMeshAgent>().Stop();
        if (useSkill==0 )
        {
            useSkill = 1;
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else if (useSkill == 1)
        {
            
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            useSkill = 2;
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else
        {
            //B³¹d
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            StateAction(ActionState.actionRunning, enemyAction);
        }
    }

    public void StateAction(ActionState enemyState, EnemyControll enemyAction)
    {
        enemyAction.SetState(enemyState);
    }

}
