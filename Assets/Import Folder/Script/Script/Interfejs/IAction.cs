using System.Collections;
using UnityEngine;


public interface IAction
{
    void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction);
    public void StateAction(ActionState enemyState, EnemyControll enemyAction);
}
