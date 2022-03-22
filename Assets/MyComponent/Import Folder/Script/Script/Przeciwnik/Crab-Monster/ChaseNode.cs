using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ChaseNode : Node
{
    private Transform target;
    private NavMeshAgent agent;
    private CrabAI ai;
    
    public ChaseNode(Transform target,NavMeshAgent agent,CrabAI ai)
    {
        this.target = target;
        this.agent = agent;
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(target.position, agent.transform.position);
        if(distance>5f)
        {
            //agent.transform.LookAt(target);
            agent.isStopped = false;
            agent.SetDestination(target.position);
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }
}
