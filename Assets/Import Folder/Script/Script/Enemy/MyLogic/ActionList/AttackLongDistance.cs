using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackLongDistance : IAction
{
    private bool attack = true;
    private float distanceFarAttack;
    public AttackLongDistance(float distanceFarAttack)
    {
        this.distanceFarAttack = distanceFarAttack;
    }


    public void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction)
    {
        if(Vector3.Distance(player.transform.position, enemy.GetComponent<NavMeshAgent>().transform.position) > distanceFarAttack - 1000f&& attack == true)
        {
            //Daleki Atak
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            enemy.transform.LookAt(new Vector3(player.transform.position.x, enemy.transform.position.y, player.transform.position.z));
            StateAction(ActionState.actionRunning, enemyAction);
            attack = false;
        }
        else if (attack == false)
        {
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            //Koniec Atak
            //enemy.GetComponent<NavMeshAgent>().isStopped = true;
            StateAction(ActionState.actionComplete, enemyAction);
            attack = true;
        }
        else
        {
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            //B³¹d
            attack = true;
            StateAction(ActionState.actionFail, enemyAction);
        }
    }

    public void StateAction(ActionState enemyState, EnemyControll enemyAction)
    {
        enemyAction.SetState(enemyState);
    }
}
