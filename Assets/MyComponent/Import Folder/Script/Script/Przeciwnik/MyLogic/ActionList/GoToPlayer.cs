using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GoToPlayer : IAction
{
    public void StateAction(ActionState enemyState,IEnemyAction enemyAction)
    {
        enemyAction.SetState(enemyState);
    }

    public IEnumerator Actions(GameObject player, NavMeshAgent enemy, float vectorDistance, float minDistance, float farDistance, IEnemyAction enemyAction,Animator animator)
    {
        if (Vector3.Distance(player.transform.position, enemy.transform.position) <= vectorDistance&& Vector3.Distance(player.transform.position, enemy.transform.position) > farDistance)
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Run", false);
            enemy.isStopped = false;
            enemy.SetDestination(player.transform.position);
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else if(Vector3.Distance(player.transform.position, enemy.transform.position) < farDistance-10f&& Vector3.Distance(player.transform.position, enemy.transform.position) > minDistance)
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Run", true);
            enemy.speed = 60;
            enemy.isStopped = false;
            enemy.SetDestination(player.transform.position);
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else if (Vector3.Distance(player.transform.position, enemy.transform.position) <= minDistance|| Vector3.Distance(player.transform.position, enemy.transform.position) > farDistance - 10f)
        { 
            enemy.isStopped = true;
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            StateAction(ActionState.actionComplete, enemyAction);
        }
        else
        {
            enemy.isStopped = true;
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            StateAction(ActionState.actionFail, enemyAction);
        }
        yield return null;
    }
}
