using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEssenceBuff : MonoBehaviour
{
    [SerializeField] private int buffValue = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            GameInformation.AddEssence(buffValue, 0);
            Destroy(this.gameObject);
        }
    }
}
