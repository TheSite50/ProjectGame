using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    [SerializeField] private GameObject endObj;
    // Start is called before the first frame update
    private void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, endObj.transform.position, Time.deltaTime);
    }
}
