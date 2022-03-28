using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAction 
{
    //ActionState StateAction(ActionState enemyAction);
    void SetState(ActionState actionState);
    void SetPlayer(GameObject player);
}

public enum ActionState
{
    actionComplete =0,
    actionFail = 1,
    actionRunning=2
}