using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackInMove : IAction
{
    
    private float distanceDetection;
    private float distanceLowAttack;
    private float distanceFarAttack;
    public AttackInMove(float distanceDetection, float distanceLowAttack, float distanceFarAttack)
    {
        this.distanceDetection = distanceDetection;
        this.distanceLowAttack = distanceLowAttack;
        this.distanceFarAttack = distanceFarAttack;
    }


    public void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction)
    {
        if (Vector3.Distance(player.transform.position, enemy.GetComponent<NavMeshAgent>().transform.position) < distanceFarAttack &&
            Vector3.Distance(player.transform.position, enemy.GetComponent<NavMeshAgent>().transform.position) > distanceLowAttack )
        {
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            enemy.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            enemy.transform.LookAt(new Vector3(player.transform.position.x, enemy.transform.position.y, player.transform.position.z));
            StateAction(ActionState.actionRunning, enemyAction);
            
        }
        else if (Vector3.Distance(player.transform.position, enemy.GetComponent<NavMeshAgent>().transform.position) < distanceLowAttack)
        {
            StateAction(ActionState.actionComplete, enemyAction);
            
        }
        else
        {
            //B³¹d
            
            StateAction(ActionState.actionFail, enemyAction);
        }
    }

    public void StateAction(ActionState enemyState, EnemyControll enemyAction)
    {
        enemyAction.SetState(enemyState);
    }
}

