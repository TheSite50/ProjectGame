using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderRangeNode : Node
{
    private float range;
    private Transform target;
    private Transform origin;

    public WanderRangeNode(float range, Transform target, Transform origin)
    {
        this.range = range; //Zasi�g
        this.target = target; //Cel
        this.origin = origin; //Aktualna pozycja
    }

    public override NodeState Evaluate()
    {
        origin.gameObject.transform.LookAt(target);
        float distance = Vector3.Distance(target.position, origin.position);// Sprzewdza odleg�o�� od celu
        return distance >= range ? NodeState.SUCCESS : NodeState.FAILING; //Je�li cel jest za daleko, sukces
    }

}
