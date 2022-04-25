using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroBarier :MonoBehaviour, IAccesories
{
    [SerializeField] ParticleSystem effect;
    public void UseSuperPower()
    {
        Instantiate<ParticleSystem>(effect, this.transform);
    }
}
