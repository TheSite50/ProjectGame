using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPartScript : MonoBehaviour
{
    [SerializeField] private UpperPartScript upperPartScript;
    [SerializeField] private MovementScript movementScript;
    [SerializeField]private float rotationSpeed = 10f;
    private void FixedUpdate()
    {
        transform.forward = Vector3.Lerp(transform.forward, movementScript.move, rotationSpeed);
    }
}
