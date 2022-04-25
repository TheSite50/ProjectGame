using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyAction : MonoBehaviour
{
    [Header("Enemy Action Parameter")] 
    [SerializeField] protected float distanceDetection;
    [SerializeField] protected float distanceLowAttack;
    [SerializeField] protected float distanceFarAttack;
    [SerializeField] protected GameObject muzzle;
    [SerializeField] protected Slider sliderHp;
    protected GameObject player;

    //ActionState StateAction(ActionState enemyAction);
    public abstract void SetState(ActionState actionState);
    public abstract void SetPlayer(GameObject player);

}

public enum ActionState
{
    actionComplete =0,
    actionFail = 1,
    actionRunning=2
}