using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IAction 
{
    IEnumerator Actions(GameObject player, NavMeshAgent enemy, float vectorDistance, float minDistance, float farDistance, IEnemyAction enemyAction,Animator animator);
    public void StateAction(ActionState enemyState, IEnemyAction enemyAction);
}
