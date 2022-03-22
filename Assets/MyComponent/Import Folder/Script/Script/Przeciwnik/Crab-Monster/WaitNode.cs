using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitNode : Node
{
    private int time=0;
    private int waitTime;

    public WaitNode(int waitTime)
    {
        this.waitTime = waitTime;
    }
    public override NodeState Evaluate()
    {
        if (time < waitTime)
        {
            time++;
        }
        else
        {
            return NodeState.SUCCESS;
        }
        return NodeState.RUNNING;
    }
}
