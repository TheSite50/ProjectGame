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
            //IdŸ do gracza jeœli jest w zasiêgu
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            UseThisSkill();
            StateAction(ActionState.actionRunning, enemyAction);
        }
        if (false)
        {

            //Przerwij pod¹¿anie do gracza
            enemy.GetComponent<NavMeshAgent>().isStopped = true;

            StateAction(ActionState.actionFail, enemyAction);
        }
        else
        {
            //B³¹d
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
