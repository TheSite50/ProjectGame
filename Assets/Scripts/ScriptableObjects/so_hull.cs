using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hull",menuName ="ScriptableObjects/Hulls")]
public class so_hull : ScriptableObject
{
    public GameObject model;
    public GameObject leftGunModel;
    public GameObject rightGunModel;
}
