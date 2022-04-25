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
    
    private Node topNode;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

   // public void Attack()
   // {
   //     this.GetComponent<Animator>().SetTrigger("Attack_2");
   // }
   //
    // Start is called before the first frame update
    void Start()
    {
        ConstructBehaviourTree();
    }

    private void ConstructBehaviourTree()
    {
        
        RangeNode chasingRangeNode = new RangeNode(distance, playerTransform, this.gameObject.transform);//zasiêg poœcigu
        RangeNode attackRangeNode = new RangeNode(attackDistance, playerTransform, this.gameObject.transform);
        AttackNode attackNode = new AttackNode(playerTransform,agent, this);
        ChaseNode chaseNode = new ChaseNode(playerTransform, agent, this); //poœcig
        

        Sequencer attackSequencer = new Sequencer(new List<Node> { attackRangeNode, attackNode });
        Sequencer chaseSequencer = new Sequencer(new List<Node> { chasingRangeNode, chaseNode });
        //Selector mainSelector = new Selector(new List<Node> { chasingRangeNode, waitNode });
        topNode= new Selector(new List<Node> {  attackSequencer, chaseSequencer});
       //this.GetComponent<Animator>().SetTrigger("Walk_Cycle_2");
    }

    // Update is called once per frame
    void Update()
    {
        topNode.Evaluate();
    }
}
