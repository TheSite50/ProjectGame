using System.Collections;
using UnityEngine;


public interface IAction
{
    void Actions(GameObject player, GameObject enemy, EnemyProperties enemyAction);
    public void StateAction(ActionState enemyState, EnemyProperties enemyAction);
}
