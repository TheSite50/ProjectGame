using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAttack : IAction
{
    private bool attack = true;
    private float distanceFarAttack;
    public FlyAttack(float distanceFarAttack)
    {
        this.distanceFarAttack = distanceFarAttack;
    }


    public void Actions(GameObject player, GameObject enemy, EnemyProperties enemyAction)
    {
        if (Vector3.Distance(player.transform.position, enemy.transform.position) > distanceFarAttack - 1000f&& attack == true)
        {
            //Daleki Atak
            enemy.GetComponent<Animator>().SetBool("FlyAttack", true);
            enemy.transform.LookAt(new Vector3(player.transform.position.x, enemy.transform.position.y, player.transform.position.z));
            StateAction(ActionState.actionRunning, enemyAction);
            attack = false;
        }
        else if (attack == false)
        {
            //Koniec Atak
            StateAction(ActionState.actionFail, enemyAction);
            attack = true;
        }
        else
        {
            //B��d
            attack = true;
            StateAction(ActionState.actionFail, enemyAction);
        }
    }

    public void StateAction(ActionState enemyState, EnemyProperties enemyAction)
    {
        enemyAction.SetState(enemyState);
    }
}
