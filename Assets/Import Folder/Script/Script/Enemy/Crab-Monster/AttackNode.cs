using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AttackNode : Node
{
    private NavMeshAgent agent;
    private CrabAI ai;
    private Transform target;
   
    public AttackNode(Transform target,NavMeshAgent agent, CrabAI ai)
    {
        this.agent = agent;
        this.ai = ai;
        this.target = target; 
    }
    public override NodeState Evaluate()
    {
        //agent.transform.LookAt(target);
        agent.isStopped = true;
        //ai.Attack();
        return NodeState.SUCCESS;
    }
}
