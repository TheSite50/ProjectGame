using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_EnemyAnimationMenage : MonoBehaviour
{
    private EnemyProperties enemy; 
    private int NumberActionInAir = -1;
    Dictionary<(int, int), string> dictionaryAnimation = new Dictionary<(int, int), string>();
    private Animator animatorFly;
    private void Awake()
    {
        enemy = this.GetComponent<EnemyProperties>();
        animatorFly = this.GetComponent<Animator>();

        dictionaryAnimation.Add((-1, 2), "Attack");
        dictionaryAnimation.Add((-1, 3), "Strong_Attack");
    }

    private void Update()
    {
        if (NumberActionInAir != enemy.NumberAction().inAir)
        {
            if (NumberActionInAir != -1&& NumberActionInAir!=0&& NumberActionInAir != 1)
            {
                animatorFly.SetBool(dictionaryAnimation[(-1, NumberActionInAir)], false);
            }

            if (enemy.NumberAction().inAir == 0 || enemy.NumberAction().inAir == 1)
            {
                return;
            }
            else
            {
                animatorFly.SetBool(dictionaryAnimation[(-1, enemy.NumberAction().inAir)], true);
                NumberActionInAir = enemy.NumberAction().inAir;
            }
        }
        
    }
}
