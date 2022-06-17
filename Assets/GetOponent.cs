using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOponent : MonoBehaviour
{
    [SerializeField] private GameObject portal;
    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<EnemyAction>()==true)
        {
            this.gameObject.transform.LookAt(FindObjectOfType<EnemyAction>().gameObject.transform.position);
        }
        else
        {
            this.gameObject.transform.LookAt(portal.gameObject.transform.position);
        }
    }
}
