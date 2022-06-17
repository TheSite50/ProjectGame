using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class BossProperties : BossAction,IHp,IDamage
{
    [Header("Statistic")]
    [SerializeField] protected float valueHp = 0;
    [SerializeField] private float damage = 0;
    public abstract (bool isInFly, int onGround, int inAir) NumberAction();

    public void SetHp(float hp)
    {
        this.valueHp = hp;
    }
    public float GetHp()
    {
        return valueHp;
    }

    public float GetDamage()
    {
        return this.damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
            this.gameObject.GetComponent<IHp>().SetHp(this.gameObject.GetComponent<IHp>().GetHp() - collision.gameObject.GetComponent<IDamage>().GetDamage());
    }
}
