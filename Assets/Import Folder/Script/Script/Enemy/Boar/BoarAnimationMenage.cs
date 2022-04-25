using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoarAnimationMenage : MonoBehaviour
{
    private EnemyProperties enemy;
    private int NumberActionOnGround = -1;
    private int NumberActionInAir = -1;
    Dictionary<(int,int), string> dictionaryAnimation = new Dictionary<(int, int), string>();
    private void Awake()
    {
        enemy = this.GetComponent<EnemyProperties>();


        dictionaryAnimation.Add((0, -1), "Walk");
        dictionaryAnimation.Add((1, -1), "Walk");
        dictionaryAnimation.Add((2, -1), "FarAttack");
        dictionaryAnimation.Add((3, -1), "Run");
        dictionaryAnimation.Add((4, -1), "Attack");



        dictionaryAnimation.Add((-1, 0), "Fly");
        dictionaryAnimation.Add((-1, 1), "FlyAttack");
    }

    private void Update()
    {
        if (enemy.NumberAction().isInFly == false)
        {
            if (NumberActionOnGround != enemy.NumberAction().onGround)
            {
                if(NumberActionOnGround != -1)
                {
                    this.GetComponent<Animator>().SetBool(dictionaryAnimation[(NumberActionOnGround, -1)], false); 
                }
                
                this.GetComponent<Animator>().SetBool(dictionaryAnimation[(enemy.NumberAction().onGround, -1)], true);
                NumberActionOnGround = enemy.NumberAction().onGround;
            }
        }
        else
        {
            if (NumberActionInAir != enemy.NumberAction().inAir)
            {
                if(NumberActionInAir != -1)
                { 
                    this.GetComponent<Animator>().SetBool(dictionaryAnimation[(NumberActionInAir, -1)], false);
                }
                
                this.GetComponent<Animator>().SetBool(dictionaryAnimation[(enemy.NumberAction().inAir, -1)], true);
                NumberActionInAir = enemy.NumberAction().onGround;
            }
        }
    }

}
