using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class CrabStats : MonoBehaviour
{
    private int health = 100;
    private int armor = 90;
    private bool stop = false;
    [SerializeField] Slider hpSlider;
    private void Awake()
    {
        hpSlider.maxValue = health;
        hpSlider.value = health;
    }

    private void Update()
    {
        if(hpSlider.value==0&&stop==false)
        {
            this.GetComponent<CrabAI>().enabled = false;
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<Animator>().SetTrigger("Die");
            stop = true;
        }
    }
    public void getDamage(int damage)
    {
        
        
        if (damage > armor&&stop==false)
        {
            hpSlider.value = hpSlider.value + armor - damage;
        }
        else
        {
        }
    }

}
