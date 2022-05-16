using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossGoToPlayer : IAction
{
    private float distanceDetection;
    private float distanceLowAttack;
    private bool useSkill = false;
    public BossGoToPlayer(float distanceDetection, float distanceLowAttack)
    {
        this.distanceDetection = distanceDetection;
        this.distanceLowAttack = distanceLowAttack;
        
    }
    public void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction)
    {
        if(Vector3.Distance(player.transform.position, enemy.transform.position)>400f&&Random.Range(0,100)<5)
        {
            useSkill = true;
        }
        if ((Vector3.Distance(player.transform.position, enemy.transform.position) <= distanceDetection && Vector3.Distance(player.transform.position, enemy.transform.position) > distanceLowAttack) )
        {
            //Id� do gracza je�li jest w zasi�gu
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            enemy.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else if (Vector3.Distance(player.transform.position, enemy.transform.position) < distanceLowAttack || Vector3.Distance(player.transform.position, enemy.transform.position) > distanceDetection || useSkill == true)
        {
            if(useSkill==true)
            {
                enemy.GetComponent<Boss>().SetActionNumber(5);
            }
            //Przerwij pod��anie do gracza
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            StateAction(ActionState.actionComplete, enemyAction);
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
        enemyAction.SetState(enemyState);
    }
}
