using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeNode : Node
{
    private float range;
    private Transform target;
    private Transform origin;

    public RangeNode(float range, Transform target,Transform origin)
    {
        this.range = range;//Zasiêg
        this.target = target;//Cel
        this.origin = origin;//Aktualna pozycja
    }

    public override NodeState Evaluate()
    {
        origin.gameObject.transform.LookAt(target);
        float distance = Vector3.Distance(target.position, origin.position); //Okreœla dystans
        return distance <= range ? NodeState.SUCCESS : NodeState.FAILING; //Jeœli cel jest w zasiêgu, sukces
    }

}
