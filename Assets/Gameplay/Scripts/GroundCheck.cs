using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    public bool isGrounded;
    private void OnTriggerStay(Collider other)
    {
        isGrounded = other.gameObject.layer == groundLayerMask; //other != null && (((1 << other.gameObject.layer) & groundLayerMask) !=0);//? 1<<8 = 100000000 = 256
    }
    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
