using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToPlayer : IAction
{
    private float distanceDetection;    
    private float distanceLowAttack;
    private float distanceFarAttack;
    private float flyDistance = 200f;
    private bool attack = true;
    public FlyToPlayer(float distanceDetection,  float distanceFarAttack,float distanceLowAttack)
    { 
        this.distanceDetection = distanceDetection;
        this.distanceFarAttack = distanceFarAttack;
        this.distanceLowAttack = distanceLowAttack;
    }
    public void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction)
    {
        
            
        //Shoot
        
        
        if(Vector3.Distance(player.transform.position, enemy.transform.position)>distanceFarAttack)
        {
            enemy.transform.position = Vector3.Lerp(enemy.transform.position, player.transform.position, Time.deltaTime);
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else if(Vector3.Distance(player.transform.position, enemy.transform.position)<distanceFarAttack|| Vector3.Distance(player.transform.position, enemy.transform.position) > distanceLowAttack)
        {
            enemy.transform.position = Vector3.Lerp(enemy.transform.position, enemy.transform.position + DistanceKeep(player.transform.position,enemy.transform.position),Time.deltaTime);
            StateAction(ActionState.actionComplete, enemyAction);
        }
        else if(Vector3.Distance(player.transform.position, enemy.transform.position) <= distanceFarAttack|| Vector3.Distance(player.transform.position, enemy.transform.position) >= distanceLowAttack)
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

    private float DistanceFloatDifference(float value1,float value2)
    {
        return value1 - value2;
    }

    private Vector3 DistanceKeep(Vector3 firstVector, Vector3 secondVector)
    { 
        if(Vector3.Distance(firstVector,secondVector)<100f)
        {
            return new Vector3((secondVector.x - firstVector.x ) * Random.Range(1,10), secondVector.y * 20f, ( secondVector.z - firstVector.z ) * Random.Range(1, 10));
        }

        return Vector3.up*10f;
    }
}
