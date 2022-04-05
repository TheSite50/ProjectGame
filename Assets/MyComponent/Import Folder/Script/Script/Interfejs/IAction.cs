using System.Collections;
using UnityEngine;


public interface IAction
{
    IEnumerator Actions(GameObject player, GameObject enemy, EnemyAction enemyAction);
    public void StateAction(ActionState enemyState, EnemyAction enemyAction);
}
