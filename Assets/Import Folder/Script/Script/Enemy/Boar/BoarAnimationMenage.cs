using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoarAnimationMenage : MonoBehaviour
{
    private EnemyProperties enemy;
    private int NumberActionOnGround = -1;
    private int NumberActionInAir = -1;
    Dictionary<(int,int), string> dictionaryAnimation = new Dictionary<(int, int), string>();
    private Animator animatorBoar;
    private void Awake()
    {
        enemy = this.GetComponent<EnemyProperties>();
        animatorBoar = this.GetComponent<Animator>();

        dictionaryAnimation.Add((0, -1), "Walk");
        dictionaryAnimation.Add((1, -1), "Walk");
        dictionaryAnimation.Add((2, -1), "FarAttack");
        dictionaryAnimation.Add((3, -1), "Run");
        dictionaryAnimation.Add((4, -1), "Attack");

        dictionaryAnimation.Add((-1, 0), "Fly");
        dictionaryAnimation.Add((-1, 1), "FlyAttack");
        dictionaryAnimation.Add((-1, 2), "Fly");
    }

    private void Update()
    {
        if (enemy.NumberAction().isInFly == false)
        {
            enemy.GetComponent<Animator>().SetBool("FlyAttack", false);
            enemy.GetComponent<Animator>().SetBool("Fly", false);
            if (NumberActionOnGround != enemy.NumberAction().onGround)
            {
                if(NumberActionOnGround != -1)
                {
                    animatorBoar.SetBool(dictionaryAnimation[(NumberActionOnGround, -1)], false); 
                }

                animatorBoar.SetBool(dictionaryAnimation[(enemy.NumberAction().onGround, -1)], true);
                NumberActionOnGround = enemy.NumberAction().onGround;
            }
        }
        else
        {
            if (NumberActionInAir != enemy.NumberAction().inAir)
            {
                enemy.GetComponent<Animator>().SetBool("Walk", false);
                enemy.GetComponent<Animator>().SetBool("FarAttack", false);
                enemy.GetComponent<Animator>().SetBool("Run", false);
                enemy.GetComponent<Animator>().SetBool("Attack", false);
                if (NumberActionInAir != -1)
                {
                    animatorBoar.SetBool(dictionaryAnimation[(-1,NumberActionInAir )], false);
                }

                animatorBoar.SetBool(dictionaryAnimation[(-1, enemy.NumberAction().inAir)], true);
                NumberActionInAir = enemy.NumberAction().inAir;
            }
        }
    }

}
