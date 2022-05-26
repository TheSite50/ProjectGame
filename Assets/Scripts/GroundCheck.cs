using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    public bool isGrounded;
    private void OnTriggerStay(Collider other)
    {
        isGrounded = other != null && (((1 << other.gameObject.layer) & groundLayerMask) !=0);
    }
    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
