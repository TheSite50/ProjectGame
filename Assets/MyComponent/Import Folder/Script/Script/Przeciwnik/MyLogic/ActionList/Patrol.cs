using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : IAction
{
    private bool patrol = false;
    private Vector3 destination;
    
    
    public IEnumerator Actions(GameObject player, NavMeshAgent enemy, float vectorDistance, float minDistance, float farDistance, IEnemyAction enemyAction, Animator animator)
    {
        //RaycastHit hitPoint= new RaycastHit();
        if (patrol == false)
        {
            destination = new Vector3(Random.Range(enemy.transform.position.x - 100f, enemy.transform.position.x + 100f),
                                      enemy.transform.position.y,
                                      Random.Range(enemy.transform.position.z - 100f, enemy.transform.position.z + 100f));               
           //Physics.Raycast(new Vector3(Random.Range(enemy.transform.position.x - 100f, enemy.transform.position.x + 100f),
           //                         700,
           //                          Random.Range(enemy.transform.position.z - 100f, enemy.transform.position.z + 100f)),Vector3.down,out hitPoint,2000,011);
            
            patrol = true;
        }
        if (Vector3.Distance(player.transform.position, enemy.transform.position) > vectorDistance)
        {
            animator.SetBool("Walk", true);
            enemy.isStopped = false;
            if ((int)enemy.transform.position.x == (int) destination.x&& (int) enemy.transform.position.z == (int)destination.z)
            {
                patrol = false;
            }
            enemy.SetDestination(destination);
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else if (Vector3.Distance(player.transform.position, enemy.transform.position) <= vectorDistance)
        {
            animator.SetBool("Walk", true);
            enemy.isStopped = false;
            StateAction(ActionState.actionComplete, enemyAction);
        }
        else
        {
            animator.SetBool("Walk", false);
            enemy.isStopped = false;
            StateAction(ActionState.actionFail, enemyAction);
        }
        yield return null;
    }

    public void StateAction(ActionState enemyState, IEnemyAction enemyAction)
    {
        enemyAction.SetState(enemyState);
    }
}
