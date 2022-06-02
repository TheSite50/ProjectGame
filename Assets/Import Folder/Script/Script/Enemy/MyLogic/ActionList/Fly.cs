using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : IAction
{
    private float distanceDetection;
    private Vector3 nextPatrolPosition;
    private bool patrolPositionIsSet = false;
    public Fly(float distanceDetection)
    {
        this.distanceDetection = distanceDetection;
    }
    public void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction)
    {
        
        if (Vector3.Distance(player.transform.position, enemy.transform.position) > distanceDetection)
        {
            if(Vector3.Distance(nextPatrolPosition, enemy.transform.position)<10f||patrolPositionIsSet==false)
            {
                nextPatrolPosition= new Vector3(Random.Range(enemy.transform.position.x - 1000, enemy.transform.position.x + 1000), enemy.transform.position.y, Random.Range(enemy.transform.position.z - 1000, enemy.transform.position.z + 1000));
                patrolPositionIsSet = true;
            }
            
            enemy.transform.LookAt(nextPatrolPosition);
            enemy.transform.position = Vector3.Lerp(enemy.transform.position, nextPatrolPosition, Time.deltaTime);
            StateAction(ActionState.actionRunning, enemyAction);
            
        }
        else if (Vector3.Distance(player.transform.position, enemy.transform.position) < distanceDetection)
        {
            StateAction(ActionState.actionComplete, enemyAction);
        }
        else
        {
            StateAction(ActionState.actionFail, enemyAction);
        }
       

    }

    public void StateAction(ActionState enemyState, EnemyControll enemyAction)
    {
        enemyAction.SetState(enemyState);
    }

}
