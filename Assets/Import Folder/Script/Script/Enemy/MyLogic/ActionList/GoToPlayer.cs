using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GoToPlayer : IAction
{
    private float distanceDetection;
    private float distanceLowAttack;
    private float distanceFarAttack;

    
    public GoToPlayer(float distanceDetection, float distanceLowAttack, float distanceFarAttack)
    {
        this.distanceDetection = distanceDetection;
        this.distanceLowAttack = distanceLowAttack;
        this.distanceFarAttack = distanceFarAttack;
    }
    public void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction)
    {
        if (Vector3.Distance(player.transform.position, enemy.transform.position) <= distanceDetection && Vector3.Distance(player.transform.position, enemy.transform.position)>distanceFarAttack)
        {
            //IdŸ do gracza jeœli jest w zasiêgu
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            enemy.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else if (Vector3.Distance(player.transform.position, enemy.transform.position) < distanceFarAttack || Vector3.Distance(player.transform.position, enemy.transform.position) > distanceDetection )
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
    public  void StateAction(ActionState enemyState, EnemyControll enemyAction)
    {
        enemyAction.SetState(enemyState);
    }
}
