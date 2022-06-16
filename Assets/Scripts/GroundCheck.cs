using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//used to implement
public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    public bool IsGrounded => GroundChecking();
    [SerializeField] float rayLength= 10f;
    [SerializeField] Vector3 boxBounds;
    Vector3 wherehits;
    private void Update()
    {
        GroundChecking();
        Debug.Log(IsGrounded);
    }
    private bool GroundChecking() 
    {
        Debug.DrawRay(transform.position, -transform.up*rayLength,Color.red, 5f);
      bool a =Physics.Raycast(transform.position, -transform.up, out RaycastHit hitInfo, rayLength, groundLayerMask);
        wherehits = hitInfo.point;
        
            return a;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(wherehits, boxBounds);
    }
    /*    private void OnTriggerStay(Collider other)
        {
            Debug.Log(other + " " + other.gameObject.layer);
            if (other != null) 
            {
                Debug.Log(1<<2);
            }
            //isGrounded = other != null && other.gameObject.layer;
        }
        private void OnTriggerExit(Collider other)
        {
            isGrounded = false;
        }*/
}
