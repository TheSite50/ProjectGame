using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GoToPlayer : IAction
{
    private float distanceDetection;
    private float distanceFarAttack;

    
    public GoToPlayer(float distanceDetection,  float distanceFarAttack)
    {
        this.distanceDetection = distanceDetection;
        this.distanceFarAttack = distanceFarAttack;
    }
    public void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction)
    {
        if (Vector3.Distance(player.transform.position, enemy.transform.position) <= distanceDetection && Vector3.Distance(player.transform.position, enemy.transform.position)>distanceFarAttack)
        {
            //Id� do gracza je�li jest w zasi�gu
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            enemy.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            StateAction(ActionState.actionRunning, enemyAction);
            enemy.gameObject.transform.LookAt(new Vector3(player.transform.position.x, enemy.transform.position.y, player.transform.position.z));
        }
        else if (Vector3.Distance(player.transform.position, enemy.transform.position) < distanceFarAttack || Vector3.Distance(player.transform.position, enemy.transform.position) > distanceDetection )
        {
            //Przerwij pod��anie do gracza
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            StateAction(ActionState.actionComplete, enemyAction);
            enemy.gameObject.transform.LookAt(new Vector3(player.transform.position.x, enemy.transform.position.y, player.transform.position.z));
        }
        else
        {
            //B��d
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            StateAction(ActionState.actionFail, enemyAction);
        }
    }
    public  void StateAction(ActionState enemyState, EnemyControll enemyAction)
    {
        enemyAction.SetState(enemyState);
    }
}
