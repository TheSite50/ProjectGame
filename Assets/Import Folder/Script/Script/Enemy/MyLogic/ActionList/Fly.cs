using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : IAction
{
    private float distanceDetection;    
    private float distanceFarAttack;
    private float flyDistance = 200f;
    private bool attack = true;
    public Fly(float distanceDetection,  float distanceFarAttack)
    { 
        this.distanceDetection = distanceDetection;
        this.distanceFarAttack = distanceFarAttack;
    }
    public void Actions(GameObject player, GameObject enemy, EnemyProperties enemyAction)
    {
        enemy.GetComponent<Rigidbody>().useGravity = false;
        enemy.GetComponent<Rigidbody>().isKinematic = true;
        
            
        //Shoot
        
        StateAction(ActionState.actionRunning, enemyAction);
        if(Vector3.Distance(player.transform.position, enemy.transform.position)>distanceFarAttack)
        {
            enemy.transform.position = Vector3.Lerp(enemy.transform.position, player.transform.position, Time.deltaTime/10);
        }
        else if(Vector3.Distance(player.transform.position, enemy.transform.position)<300f)
        {
            enemy.transform.position = Vector3.Lerp(enemy.transform.position, enemy.transform.position + DistanceKeep(player.transform.position,enemy.transform.position),Time.deltaTime/10);
        }
        else if(Vector3.Distance(player.transform.position, enemy.transform.position) <= distanceFarAttack )
        {
           StateAction(ActionState.actionComplete, enemyAction);
        }

    }

    public void StateAction(ActionState enemyState, EnemyProperties enemyAction)
    {
        enemyAction.SetState(enemyState);
    }

    private float DistanceFloatDifference(float value1,float value2)
    {
        return value1 - value2;
    }

    private Vector3 DistanceKeep(Vector3 firstVector, Vector3 secondVector)
    { 
        if(Vector3.Distance(firstVector,secondVector)<1000f)
        {
            return new Vector3((secondVector.x - firstVector.x ) * Random.Range(1,10), secondVector.y * 20f, ( secondVector.z - firstVector.z ) * Random.Range(1, 10));
        }

        return Vector3.up*10f;
    }
}
