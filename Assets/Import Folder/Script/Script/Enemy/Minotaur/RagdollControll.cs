using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class RagdollControll : MonoBehaviour
{
    private Rigidbody[] rigidbodyObject;
    private Collider[] collidersObject;
    private Animator animatorObject;
    private void Awake()
    {
        rigidbodyObject = GetComponentsInChildren<Rigidbody>();
        collidersObject = GetComponentsInChildren<Collider>();
        animatorObject = this.GetComponent<Animator>();
        foreach (Rigidbody rigidbody in rigidbodyObject)
        {
            rigidbody.isKinematic = false;
        }
        foreach (Collider collider in collidersObject)
        {
            collider.enabled = true;
        }
    }

    public void ActivRackdoll()
    {

        foreach( Rigidbody rigidbody in rigidbodyObject)
        {
            rigidbody.isKinematic = false;
        }
        foreach(Collider collider in collidersObject)
        {
            collider.enabled = true;
        }
        animatorObject.enabled = false;
        this.GetComponent<Collider>().enabled = true;
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<NavMeshAgent>().enabled = false;
        this.GetComponent<Boss>().enabled = false;
    }
}
