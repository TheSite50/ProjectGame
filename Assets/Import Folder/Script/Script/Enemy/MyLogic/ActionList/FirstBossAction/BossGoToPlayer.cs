using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossGoToPlayer : IAction
{
    private float distanceDetection;
    private float distanceLowAttack;
    private float distanceFarAttack;
    public BossGoToPlayer(float distanceDetection, float distanceLowAttack, float distanceFarAttack)
    {
        this.distanceDetection = distanceDetection;
        this.distanceLowAttack = distanceLowAttack;
        this.distanceFarAttack = distanceFarAttack;
    }
    public void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction)
    {
        
        if ((Vector3.Distance(player.transform.position, enemy.transform.position) <= distanceDetection && Vector3.Distance(player.transform.position, enemy.transform.position) > distanceLowAttack))
        {
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            enemy.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else if (Vector3.Distance(player.transform.position, enemy.transform.position) < distanceLowAttack  )
        {
            
            //Przerwij pod¹¿anie do gracza
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            StateAction(ActionState.actionComplete, enemyAction);
        }
        else if(Vector3.Distance(player.transform.position, enemy.transform.position) > distanceDetection)
        {
            
            //B³¹d
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            StateAction(ActionState.actionFail, enemyAction);
        }
        else
        {
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            StateAction(ActionState.actionFail, enemyAction);
        }
    }
    public void StateAction(ActionState enemyState, EnemyControll enemyAction)
    {
        enemyAction.SetState(enemyState);
    }
}
