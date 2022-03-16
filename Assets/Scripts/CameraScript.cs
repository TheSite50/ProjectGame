using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 cameraRotation;
    [SerializeField] private float sensitivity = 5;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cameraRotation);
        if (cameraRotation.x >= 70)
            cameraRotation.x = 70;
        if (cameraRotation.x <= -70)
            cameraRotation.x = -70;
        if (cameraRotation.y >= 180)
            cameraRotation.y -= 360;
        if (cameraRotation.y <= -180)
            cameraRotation.y += 360;
        cameraRotation.z = 0;
        //Debug.Log(cameraRotation);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + cameraRotation);
        //Debug.Log(transform.rotation);
    }
    public void CharacterRotation(InputAction.CallbackContext context)
    {
        Vector2 playerrotation = context.ReadValue<Vector2>().normalized;
        //Debug.Log(playerrotation);
        cameraRotation = new Vector3(-playerrotation.y* sensitivity * Time.deltaTime*50, playerrotation.x* sensitivity * Time.deltaTime*50, 0);
    }
}
