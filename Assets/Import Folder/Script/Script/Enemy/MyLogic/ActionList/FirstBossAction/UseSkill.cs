using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class UseSkill : IAction
{
    
    public UseSkill()
    {

    }

    public void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction)
    {
        if (true)
        {
            //Id� do gracza je�li jest w zasi�gu
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            UseThisSkill();
            StateAction(ActionState.actionRunning, enemyAction);
        }
        if (false)
        {

            //Przerwij pod��anie do gracza
            enemy.GetComponent<NavMeshAgent>().isStopped = true;

            StateAction(ActionState.actionFail, enemyAction);
        }
        else
        {
            //B��d
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            StateAction(ActionState.actionFail, enemyAction);
        }
    }

    public void StateAction(ActionState enemyState, EnemyControll enemyAction)
    {
        throw new System.NotImplementedException();
    }
    public void UseThisSkill()
    {

    }

}
