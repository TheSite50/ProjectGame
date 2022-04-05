using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GoToPlayer : IAction
{
    private float distanceDetection;
    private float distanceLowAttack;
    private float distanceFarAttack;

    
    public GoToPlayer(float distanceDetection, float distanceLowAttack, float distanceFarAttack)
    {
        this.distanceDetection = distanceDetection;
        this.distanceLowAttack = distanceLowAttack;
        this.distanceFarAttack = distanceFarAttack;
    }
    public  IEnumerator Actions(GameObject player, GameObject enemy, EnemyAction enemyAction)
    {
        if (Vector3.Distance(player.transform.position, enemy.transform.position) <= distanceDetection && Vector3.Distance(player.transform.position, enemy.transform.position)>distanceFarAttack)
        {
            //IdŸ do gracza jeœli jest w zasiêgu
            enemy.GetComponent<Animator>().SetBool("Walk", true);
            enemy.GetComponent<Animator>().SetBool("Run", false);
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            enemy.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else if(Vector3.Distance(player.transform.position, enemy.transform.position) < distanceFarAttack - 100f && Vector3.Distance(player.transform.position, enemy.transform.position) > distanceLowAttack)
        {
            //Biegnij do gracza jeœli jest pomiêdzy 
            enemy.GetComponent<Animator>().SetBool("Walk", true);
            enemy.GetComponent<Animator>().SetBool("Run", true);
            enemy.GetComponent<NavMeshAgent>().speed = 1000;
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            enemy.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            StateAction(ActionState.actionRunning, enemyAction);
        }
        else if (Vector3.Distance(player.transform.position, enemy.transform.position) < distanceLowAttack|| Vector3.Distance(player.transform.position, enemy.transform.position) < distanceFarAttack || Vector3.Distance(player.transform.position, enemy.transform.position) > distanceDetection )
        {
            //Przerwij pod¹¿anie do gracza
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            enemy.GetComponent<Animator>().SetBool("Walk", false);
            enemy.GetComponent<Animator>().SetBool("Run", false);
            StateAction(ActionState.actionComplete, enemyAction);
        }
        else
        {
            //B³¹d
            enemy.GetComponent<NavMeshAgent>().isStopped = true;
            enemy.GetComponent<Animator>().SetBool("Walk", false);
            enemy.GetComponent<Animator>().SetBool("Run", false);
            StateAction(ActionState.actionFail, enemyAction);
        }
        yield return null;
    }
    public  void StateAction(ActionState enemyState,EnemyAction enemyAction)
    {
        enemyAction.SetState(enemyState);
    }
}
