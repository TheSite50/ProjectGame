using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    protected NodeState nodeState;
    public NodeState getNodeStare { get { return nodeState;} }
    public abstract NodeState Evaluate();
}

public enum NodeState
{
    RUNNING,
    SUCCESS,
    FAILING,
}