using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAction : MonoBehaviour
{
    
    //ActionState StateAction(ActionState enemyAction);
    public abstract void SetState(ActionState actionState);
    public abstract void SetPlayer(GameObject player);
    public abstract (float, float, float) GetDistance();

    
}

public enum ActionState
{
    actionComplete =0,
    actionFail = 1,
    actionRunning=2
}