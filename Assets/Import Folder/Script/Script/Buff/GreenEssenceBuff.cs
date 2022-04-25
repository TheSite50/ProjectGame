using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEssenceBuff : MonoBehaviour
{
    [SerializeField] private int buffValue = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            GameInformation.SetEssence(0, buffValue);
            Destroy(this.gameObject);
        }
    }
}
