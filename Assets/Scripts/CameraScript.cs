using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 cameraRotation;
    private Transform transformA;
    [SerializeField] private float sensitivity = 5;
    void Start()
    {
        //transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(cameraRotation);
        Debug.Log(transform.rotation);
    }
    public void CharacterRotation(InputAction.CallbackContext context)
    {
        Vector2 playerrotation = context.ReadValue<Vector2>().normalized;
        
        cameraRotation = new Vector3(-playerrotation.y, playerrotation.x, 0);
        //Debug.Log(cameraRotation);
        cameraRotation *= sensitivity*Time.deltaTime;
    }
}
