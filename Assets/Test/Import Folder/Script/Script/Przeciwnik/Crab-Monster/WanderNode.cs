using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WanderNode : Node
{
    private Transform target;
    private NavMeshAgent agent;
    private CrabAI ai;


    public WanderNode(Transform target, NavMeshAgent agent, CrabAI ai)
    {
        this.target = target;
        this.agent = agent;
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {

        //Znajduje losowy punkt w odleg³oœci 5f i siê do neigo udaje
        Vector3 randomDirection = Random.insideUnitSphere * 5f;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 5f, 1);
        float distance = Vector3.Distance(hit.position, agent.transform.position);
        if (distance > 1f)
        {
            //agent.transform.LookAt(target);
            agent.isStopped = false;
            agent.SetDestination(hit.position);
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }
}
