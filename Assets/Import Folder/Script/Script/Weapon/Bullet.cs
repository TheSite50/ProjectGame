using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour,IDamage
{
    private float damage = 10f;
    private float destroyTime=0;
    private void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * 10000f);
    }
    void Update()
    {
    
        if (destroyTime < 5)
        {
            destroyTime=destroyTime+Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    public float GetDamage()
    {
        return this.damage;
    }
}
