using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject me;
    // Start is called before the first frame update
    public void Destroy()
    {
        GameObject.Destroy(me);
    }
}
