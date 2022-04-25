using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPartScript : MonoBehaviour
{
    private UpperPartScript upperPartScript;
    private MovementScript movementScript;
    [SerializeField]private float rotationSpeed = 10f;
    private void Start()
    {
        upperPartScript = CreatePlayerInGame.GetTorso().GetComponent<UpperPartScript>();
        movementScript = CreatePlayerInGame.GetPlayer().GetComponent<MovementScript>();
    }
    private void FixedUpdate()
    {
        transform.forward = Vector3.Lerp(transform.forward, movementScript.move, rotationSpeed);
    }
}
