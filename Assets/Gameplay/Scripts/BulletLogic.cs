using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//used may be outdated
public class BulletLogic : MonoBehaviour
{
    [SerializeField] private GameObject bulletDecal;
    readonly private float bulletVelocity = 500f;
    readonly private float timeToDestroy = 3f;

    public Vector3 Target { get; set; }
    public bool Hit { get; set; }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, bulletVelocity * Time.deltaTime);
        if (!Hit && Vector3.Distance(transform.position, Target) < .001f) 
        { 
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Hit = true;
        ContactPoint contact = collision.GetContact(0);
        GameObject.Instantiate(bulletDecal, contact.point + contact.normal*0.0001f, Quaternion.LookRotation(contact.normal));
        Destroy(gameObject);   
    }
}
