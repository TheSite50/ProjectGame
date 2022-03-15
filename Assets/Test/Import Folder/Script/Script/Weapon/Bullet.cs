using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private int damage=100;
    private float destroyTime=0;
    void Update()
    {
        this.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward*1000f);

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
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<CrabStats>().getDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
