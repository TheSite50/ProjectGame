using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackShortDistance : IAction
{
    private bool attack = true;
    private float distanceLowAttack;

    public AttackShortDistance(float distanceLowAttack)
    {
        this.distanceLowAttack = distanceLowAttack;
    }


    public void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction)
    {

        if (Vector3.Distance(player.transform.position, enemy.GetComponent<NavMeshAgent>().transform.position) <= distanceLowAttack && attack==true)
        {
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            //Bliski Atak
            enemy.gameObject.transform.LookAt(new Vector3(player.transform.position.x,enemy.transform.position.y,player.transform.position.z));
            StateAction(ActionState.actionRunning, enemyAction);
            attack = false;
        }
        else if (attack==false)
        {
            //Koniec Atak
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
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

    public void StateAction(ActionState enemyState, EnemyControll enemy)
    {
        enemy.SetState(enemyState);
    }
}

//succes when attack complete
//false when dont complete
//runn when attack