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
        //Debug.Log(cameraRotation);
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -70f, 70f);
        if (cameraRotation.y >= 180)
            cameraRotation.y -= 360;
        if (cameraRotation.y <= -180)
            cameraRotation.y += 360;
        cameraRotation.z = 0;
        //Debug.Log(cameraRotation);
        transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, transform.rotation.eulerAngles + cameraRotation, 0.5f));
        //Debug.Log(transform.rotation);
    }
    public void CharacterRotation(InputAction.CallbackContext context)
    {
        Vector2 playerrotation = context.ReadValue<Vector2>().normalized;
        //Debug.Log(playerrotation);
        cameraRotation = new Vector3(-playerrotation.y* sensitivity * Time.deltaTime*50, playerrotation.x* sensitivity * Time.deltaTime*50, 0);
    }
}
