using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackShortDistance : IAction
{
    private bool attack = true;
    public IEnumerator Actions(GameObject player,  NavMeshAgent enemy, float vectorDistance, float minDistance, float farDistance, IEnemyAction enemyAction, Animator animator)
    {

        if (Vector3.Distance(player.transform.position, enemy.transform.position) <= minDistance&&attack==true)
        {
            animator.SetBool("Attack",true);
            animator.SetBool("FarAttack", false);
            
            enemy.gameObject.transform.LookAt(new Vector3(player.transform.position.x,enemy.transform.position.y,player.transform.position.z));
            StateAction(ActionState.actionRunning, enemyAction);
            attack = false;
        }
        else if(Vector3.Distance(player.transform.position, enemy.transform.position) > farDistance - 10f&& Vector3.Distance(player.transform.position, enemy.transform.position)<=farDistance && attack == true)
        {
            animator.SetBool("Attack", false);
            animator.SetBool("FarAttack", true);

            enemy.gameObject.transform.LookAt(new Vector3(player.transform.position.x, enemy.transform.position.y, player.transform.position.z));
            StateAction(ActionState.actionRunning, enemyAction);
            attack = false;
        }
        else if (attack==false)
        {
            animator.SetBool("Attack", false);
            animator.SetBool("FarAttack", false);
            enemy.isStopped = true;
            StateAction(ActionState.actionComplete, enemyAction);
            attack = true;
        }
        else
        {
            animator.SetBool("Attack", false);
            animator.SetBool("FarAttack", false);
            StateAction(ActionState.actionFail, enemyAction);
        }
        yield return null;
    }

    public void StateAction(ActionState enemyState, IEnemyAction enemyAction)
    {
        enemyAction.SetState(enemyState);
    }
}

//succes when attack complete
//false when dont complete
//runn when attack