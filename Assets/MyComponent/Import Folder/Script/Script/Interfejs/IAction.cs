using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IAction 
{
    IEnumerator Actions(GameObject player,GameObject enemy,IEnemyAction enemyAction,  float vectorDistance, float minDistance, float farDistance );
    public void StateAction(ActionState enemyState, IEnemyAction enemyAction);
}
