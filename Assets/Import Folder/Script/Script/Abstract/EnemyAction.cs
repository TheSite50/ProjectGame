using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyAction : EnemyControll
{
    [Header("Enemy Action Parameter")] 
    [SerializeField] protected float distanceDetection=-1;
    [SerializeField] protected float distanceLowAttack=-1;
    [SerializeField] protected float distanceFarAttack=-1;
    //[SerializeField] protected GameObject muzzle;
    [SerializeField] protected Slider sliderHp;
    protected GameObject player;
    public abstract void SetPlayer(GameObject player);
    //ActionState StateAction(ActionState enemyAction);


}

public enum ActionState
{
    actionComplete =0,
    actionFail = 1,
    actionRunning=2
}