using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechElement :MonoBehaviour, IFieldConect
{
    [SerializeField] private GameObject[] tabConectField;
    public GameObject GetFieldConect(int fieldNumber)
    {
        return tabConectField[fieldNumber];
    }
}
