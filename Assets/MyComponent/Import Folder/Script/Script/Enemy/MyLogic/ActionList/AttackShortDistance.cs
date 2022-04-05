using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackShortDistance : IAction
{
    private bool attack = true;
    private float distanceLowAttack;

    public AttackShortDistance(float distanceLowAttack)
    {
        this.distanceLowAttack = distanceLowAttack;
    }


    public IEnumerator Actions(GameObject player, GameObject enemy, EnemyAction enemyAction)
    {

        if (Vector3.Distance(player.transform.position, enemy.GetComponent<NavMeshAgent>().transform.position) <= distanceLowAttack &&attack==true)
        {
            //Bliski Atak
            enemy.GetComponent<Animator>().SetBool("Attack",true);
            enemy.GetComponent<Animator>().SetBool("FarAttack", false);
            
            enemy.gameObject.transform.LookAt(new Vector3(player.transform.position.x,enemy.transform.position.y,player.transform.position.z));
            StateAction(ActionState.actionRunning, enemyAction);
            attack = false;
        }
        //else if(Vector3.Distance(player.transform.position, enemy.transform.position) >  - 100f&& Vector3.Distance(player.transform.position, enemy.transform.position)<= enemyAction.GetDistance().Item3 && attack == true)
        //{
        //    //Daleki Atak
        //    enemy.GetComponent<Animator>().SetBool("Attack", false);
        //    enemy.GetComponent<Animator>().SetBool("FarAttack", true);
        //    
        //    enemy.transform.LookAt(new Vector3(player.transform.position.x, enemy.transform.position.y, player.transform.position.z));
        //    StateAction(ActionState.actionRunning, enemyAction);
        //    attack = false;
        //}
        else if (attack==false)
        {
            //Koniec Atak
            enemy.GetComponent<Animator>().SetBool("Attack", false);
            enemy.GetComponent<Animator>().SetBool("FarAttack", false);
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            StateAction(ActionState.actionComplete, enemyAction);
            attack = true;
        }
        else
        {
            //B³¹d
            attack = true;
            enemy.GetComponent<Animator>().SetBool("Attack", false);
            enemy.GetComponent<Animator>().SetBool("FarAttack", false);
            StateAction(ActionState.actionFail, enemyAction);
        }
        yield return null;
    }

    public void StateAction(ActionState enemyState, EnemyAction enemy)
    {
        enemy.SetState(enemyState);
    }
}

//succes when attack complete
//false when dont complete
//runn when attack