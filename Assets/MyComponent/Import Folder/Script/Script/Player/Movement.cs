using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : ScriptableObject
{
    private Vector3 actorPosition;
    public void ActorMovement(GameObject actor,Quaternion horizontalQuaternion ,Camera camera,float speed,Animator animator,bool isOnGround) 
    {
            
    
        if (isOnGround)
        {
            if(Input.GetAxis("Vertical") * speed>0.01f)
            actor.transform.rotation = Quaternion.Lerp(actor.transform.rotation, horizontalQuaternion,Time.deltaTime*5);
            animator.SetFloat("Forward", Mathf.Abs(Input.GetAxis("Vertical") * speed));
            actorPosition = actor.transform.forward * Input.GetAxis("Vertical") * speed + Physics.gravity * Time.deltaTime + actor.transform.right * Input.GetAxis("Horizontal") * speed;
            
            
        }
        else 
        {

            //transform.Rotate(0, rotationControler.transform.localRotation.y, 0);

            animator.SetFloat("Forward", Mathf.Abs(Input.GetAxis("Vertical") * speed));

            actorPosition = camera.transform.forward * 0f + Physics.gravity * Time.deltaTime + camera.transform.right * 0f; //he dont contact with ground
    
        }
    
        actor.GetComponent<CharacterController>().Move(actorPosition);
            
    }
}
