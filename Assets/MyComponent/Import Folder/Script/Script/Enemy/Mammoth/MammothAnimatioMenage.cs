using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MammothAnimatioMenage : MonoBehaviour
{
    private EnemyProperties enemy;
    private int NumberActionOnGround = -1;
    Dictionary<(int, int), string> dictionaryAnimation = new Dictionary<(int, int), string>();
    private void Awake()
    {
        enemy = this.GetComponent<EnemyProperties>();


        dictionaryAnimation.Add((0, -1), "Movement"); 
        dictionaryAnimation.Add((1, -1), "Movement");
        dictionaryAnimation.Add((2, -1), "Fire");
        dictionaryAnimation.Add((3, -1), "NearAttack");

    }

    private void Update()
    {
        if (enemy.NumberAction().isInFly == false)
        {
            if (NumberActionOnGround != enemy.NumberAction().onGround)
            {
                if (NumberActionOnGround != -1)
                {
                    this.GetComponent<Animator>().SetBool(dictionaryAnimation[(NumberActionOnGround, -1)], false);
                }

                this.GetComponent<Animator>().SetBool(dictionaryAnimation[(enemy.NumberAction().onGround, -1)], true);
                NumberActionOnGround = enemy.NumberAction().onGround;
            }
        }
    }

}
