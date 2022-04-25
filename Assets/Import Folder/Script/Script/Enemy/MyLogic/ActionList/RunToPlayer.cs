using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunToPlayer : IAction
{
    private float distanceDetection;
    private float distanceLowAttack;
    private float distanceFarAttack;


    public RunToPlayer(float distanceDetection, float distanceLowAttack, float distanceFarAttack)
    {
        this.distanceDetection = distanceDetection;
        this.distanceLowAttack = distanceLowAttack;
        this.distanceFarAttack = distanceFarAttack;
    }
    public void Actions(GameObject player, GameObject enemy, EnemyProperties enemyAction)
    {
        if (Vector3.Distance(player.transform.position, enemy.transform.position) < distanceFarAttack - 100f && Vector3.Distance(player.transform.position, enemy.transform.position) > distanceLowAttack)
        {
            //Biegnij do gracza jeœli jest pomiêdzy 
            enemy.GetComponent<NavMeshAgent>().speed = 10000;
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            enemy.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else if (Vector3.Distance(player.transform.position, enemy.transform.position) < distanceLowAttack || Vector3.Distance(player.transform.position, enemy.transform.position) > distanceDetection)
        {
            //Przerwij pod¹¿anie do gracza
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            StateAction(ActionState.actionComplete, enemyAction);
        }
        else
        {
            //B³¹d
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            StateAction(ActionState.actionFail, enemyAction);
        }
    }
    public void StateAction(ActionState enemyState, EnemyProperties enemyAction)
    {
        enemyAction.SetState(enemyState);
    }
}
