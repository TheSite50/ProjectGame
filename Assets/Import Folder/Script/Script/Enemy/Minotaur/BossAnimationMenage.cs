using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationMenage : MonoBehaviour
{
    private BossProperties enemy;
    private int NumberActionOnGround = -1;
    Dictionary<(int, int), string> dictionaryAnimation = new Dictionary<(int, int), string>();
    private Animator animatorBoss;
    private void Awake()
    {
        enemy = this.GetComponent<BossProperties>();
        animatorBoss = this.GetComponent<Animator>();

        //dictionaryAnimation.Add((0, -1), "Idle");
        dictionaryAnimation.Add((0, -1), "Movement");
        dictionaryAnimation.Add((1, -1), "Movement");
        dictionaryAnimation.Add((2, -1), "Attack");
        dictionaryAnimation.Add((3, -1), "Attack2"); 
        dictionaryAnimation.Add((4, -1), "Run");
        
        dictionaryAnimation.Add((5, -1), "Skill");
        dictionaryAnimation.Add((6, -1), "Jump");

    }

    // Update is called once per frame
    void Update()
    {
        if (NumberActionOnGround != enemy.NumberAction().onGround)
        {
            if (NumberActionOnGround != -1)
            {
                animatorBoss.SetBool(dictionaryAnimation[(NumberActionOnGround, -1)], false);
                
            }
            
            animatorBoss.SetBool(dictionaryAnimation[(enemy.NumberAction().onGround, -1)], true);
            NumberActionOnGround = enemy.NumberAction().onGround;
        }
    }
}
