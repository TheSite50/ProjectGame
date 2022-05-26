using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAttack : IAction
{
    private bool attack = true;
    private float distanceLowAttack = 0;
    private int typeAttack = 0;
    BossStrongAttack strongAttack = new BossStrongAttack();
    BossWeakAttack weakAttack = new BossWeakAttack();

    public BossAttack(float distanceLowAttack)
    {
        this.distanceLowAttack = distanceLowAttack;
    }
    public void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction)
    {
        
        if (Vector3.Distance(player.transform.position, enemy.GetComponent<NavMeshAgent>().transform.position) <= distanceLowAttack && attack == true)
        {
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            enemy.gameObject.transform.LookAt(new Vector3(player.transform.position.x, enemy.transform.position.y, player.transform.position.z));
            if(Random.Range(0, 10)<2&& attack == true)
            {
                typeAttack = 1;
            }
            else if(attack==true)
            {
                typeAttack = 0;
            }
            
            if(typeAttack==0)
            {
                enemy.GetComponent<Boss>().SetActionNumber(3);
            }
            StateAction(ActionState.actionRunning, enemyAction);
            
            attack = false;
        }
        else if (attack == false)
        {
            if (typeAttack == 0)
            {
                enemy.GetComponent<Boss>().SetActionNumber(2);
            }
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            StateAction(ActionState.actionComplete, enemyAction);
            attack = true;
        }
        else
        {
            attack = true;
            StateAction(ActionState.actionFail, enemyAction);
        }
    }

    public void StateAction(ActionState enemyState, EnemyControll enemyAction)
    {
        enemyAction.SetState(enemyState);
    }
}
