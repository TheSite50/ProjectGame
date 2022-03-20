using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabAI : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float distance;
    [SerializeField] float attackDistance;
    //[SerializeField] Animator animator;
    //[SerializeField] AudioSource moveAudio;
    private Node topNode;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    public void Attack()
    {
       // moveAudio.Stop();
       // animator.GetComponent<Animator>().SetTrigger("Attack");
    }
    public void Movement()
    {
        //moveAudio.Play();
        //animator.GetComponent<Animator>().SetTrigger("Movement");
    }
    // Start is called before the first frame update
    void Start()
    {
        ConstructBehaviourTree();
    }

    private void ConstructBehaviourTree()
    {

        RangeNode chasingRangeNode = new RangeNode(distance, playerTransform, this.gameObject.transform);  //Okreœla wymagany zasiêg do poœcigu
        RangeNode attackRangeNode = new RangeNode(attackDistance, playerTransform, this.gameObject.transform); // Okreœla ymagany zasiêg do ataku
        AttackNode attackNode = new AttackNode(playerTransform, agent, this); // Rozpoczyna atak
        ChaseNode chaseNode = new ChaseNode(playerTransform, agent, this);  // Rozpoczyna poœcig


        Sequencer attackSequencer = new Sequencer(new List<Node> { attackRangeNode, attackNode }); //Przygotowuje sequencer ataku
        Sequencer chaseSequencer = new Sequencer(new List<Node> { chasingRangeNode, chaseNode }); //Przygotowuje sequencer poœcigu
        //Selector mainSelector = new Selector(new List<Node> { chasingRangeNode, waitNode });
        topNode = new Selector(new List<Node> { attackSequencer, chaseSequencer }); //Tworzy g³ównego node'a
        //animator.GetComponent<Animator>().SetTrigger("");
    }

    // Update is called once per frame
    void Update()
    {
        topNode.Evaluate(); //Oddelegowuje zachowanie do odpowiedniego node'a 
    }
}
