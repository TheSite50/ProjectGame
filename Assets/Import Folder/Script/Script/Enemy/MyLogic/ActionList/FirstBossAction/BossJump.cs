using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossJump : IAction
{
    private float distanceDetection;
    private float distanceLowAttack;
    private float distanceFarAttack;
    public BossJump(float distanceDetection, float distanceLowAttack, float distanceFarAttack)
    {
        this.distanceDetection = distanceDetection;
        this.distanceLowAttack = distanceLowAttack;
        this.distanceFarAttack = distanceFarAttack;
    }
    public void Actions(GameObject player, GameObject enemy, EnemyControll enemyAction)
    {
        if ((Vector3.Distance(player.transform.position, enemy.transform.position) <= distanceFarAttack && Vector3.Distance(player.transform.position, enemy.transform.position) > distanceLowAttack))
        {
            Vector3.Lerp(enemy.transform.position, (player.transform.position - enemy.transform.position).normalized * 100f, Time.deltaTime);
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else if (Vector3.Distance(player.transform.position, enemy.transform.position) < distanceLowAttack || Vector3.Distance(player.transform.position, enemy.transform.position) > distanceFarAttack)
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
