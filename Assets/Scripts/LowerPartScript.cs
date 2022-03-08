using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerPartScript : MonoBehaviour
{
    private Vector2 rotation;
    private Vector3 movement;
    private Transform cameraTransform;
    [SerializeField] private UpperPartScript upperPartScript;
    [SerializeField] private MovementScript movementScript;
    [SerializeField]private float rotationSpeed = 1f;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;

    }
    private void Update()
    {
        rotation = movementScript.direction;
        movement = new Vector3(rotation.x, 0.0f, rotation.y);
        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, movementScript.CharacterRotation(), rotationSpeed * Time.deltaTime);
    }
}
