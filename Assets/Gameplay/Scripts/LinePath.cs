using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class LinePath : MonoBehaviour
{
    [SerializeField] LineRenderer line; //to hold the line Renderer
    [SerializeField] Transform target; //to hold the transform of the target
    [SerializeField] Transform agent; //to hold the agent of this gameObject
    



    public void getPath()
    {
        
        line.enabled = true;
        target = Object.FindObjectOfType<EnemyAction>().transform;
        if(Object.FindObjectOfType<EnemyAction>())
        {
            line.SetPosition(0, agent.position); //set the line's origin
            line.SetPosition(1, target.position);
            Invoke("DisableLine", 1f);
        }
       
        //agent.SetDestination(target.position); //create the path
        //yield WaitForEndOfFrame(); //wait for the path to generate

        //DrawPath(agent.path);

        

    }
    public void DisableLine()
    {
        line.enabled = false;
    }

    
}
