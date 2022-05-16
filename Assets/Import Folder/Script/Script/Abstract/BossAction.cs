using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class BossAction : EnemyControll
{ 
    [Header("Enemy Action Parameter")]
    [SerializeField] protected float distanceDetection;
    [SerializeField] protected float distanceLowAttack;
    [SerializeField] protected float distanceFarAttack;
    [SerializeField] protected Slider sliderHp;
    [SerializeField] protected GameObject player=null;

    //ActionState StateAction(ActionState enemyAction);
}


