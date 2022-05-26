using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_EnemyAnimationMenage : MonoBehaviour
{
    private EnemyProperties enemy;
    private int NumberActionOnGround = -1;
    Dictionary<(int, int), string> dictionaryAnimation = new Dictionary<(int, int), string>();
    private Animator animatorIceEnemy;
    private void Awake()
    {
        enemy = this.GetComponent<EnemyProperties>();
        animatorIceEnemy = this.GetComponent<Animator>();

        dictionaryAnimation.Add((0, -1), "Movement");
        dictionaryAnimation.Add((1, -1), "MovementWithSword");
        dictionaryAnimation.Add((2, -1), "Attack");
        dictionaryAnimation.Add((3, -1), "Attack2");
        dictionaryAnimation.Add((4, -1), "Attack3");
    }

    private void Update()
    {
        if (NumberActionOnGround != enemy.NumberAction().onGround)
        {
            if (NumberActionOnGround != -1)
            {
                animatorIceEnemy.SetBool(dictionaryAnimation[(NumberActionOnGround, -1)], false);
            }

            animatorIceEnemy.SetBool(dictionaryAnimation[(enemy.NumberAction().onGround, -1)], true);
            NumberActionOnGround = enemy.NumberAction().onGround;
        }
    }

}
