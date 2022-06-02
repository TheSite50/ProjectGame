using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Enemy : EnemyProperties
{

    [SerializeField] private ParticleSystem bulletProjectile;
    [SerializeField] private ParticleSystem strongBulletProjectile;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private GameObject muzzle2;
    private RandomEnemySpawnBuff spawnBuff;
    private List<IAction> listEnemyActionInAir;
    private int numberActionInAir = 0;
    private ActionState actionState;
    private bool ILive = true;
    private bool leftHandAttack = true;
    private short counter = 0;
    private void Awake()
    {
        spawnBuff = this.GetComponent<RandomEnemySpawnBuff>();

        listEnemyActionInAir = new List<IAction>();
        listEnemyActionInAir.Add(new Fly(distanceDetection));
        listEnemyActionInAir.Add(new FlyToPlayer(distanceDetection, distanceFarAttack, distanceLowAttack));
        listEnemyActionInAir.Add(new FlyAttack(distanceLowAttack));
        listEnemyActionInAir.Add(new FlyAttack(distanceLowAttack));
    }

    // Update is called once per frame
    void Update()
    {
        sliderHp.value = this.GetHp() / 100f;
        

        if(this.GetHp()<=0&&ILive==true)
        {
            Death();
        }
        if(ILive==false)
        {
            this.transform.position = Vector3.Lerp(this.gameObject.transform.position, this.gameObject.transform.position + Vector3.down * 100f, Time.deltaTime);
            if(this.transform.position.y<=-50)
            {
                Destroy(this.gameObject);

            }
        }
        //idŸ do gracza
        //atakuj gracza
        //u¿yj umiejêtnoœci
        //zmieñ rodzej ataku
        if (player != null&& ILive==true)
        {
            if(numberActionInAir==2&& counter<10)
            {
                counter++;
            }
            else if(counter==10)
            {
                numberActionInAir = 3;
                counter = 0;
            }
            listEnemyActionInAir[numberActionInAir].Actions(player, this.gameObject, this);
            if (actionState == ActionState.actionComplete)
            {
                numberActionInAir = numberActionInAir < 2 ? numberActionInAir + 1 : 2;
            }
            else if (actionState == ActionState.actionFail)
            {
                numberActionInAir = 0;
            }
            else
            {
            }
            
            muzzle.transform.LookAt(player.transform.position);
            muzzle2.transform.LookAt(player.transform.position);
        }
    }

    private void Death()
    {
        
        ILive = false;
        spawnBuff.SpawnBuff();
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<Fly_EnemyAnimationMenage>().enabled = false;

    }

    public override void SetState(ActionState actionState)
    {
        this.actionState = actionState;
    }

    public override void SetPlayer(GameObject player)
    {
        this.player = player;
    }
    public void Attack()
    {
        if(leftHandAttack==true)
        {
            Instantiate<ParticleSystem>(bulletProjectile, muzzle.transform.position, muzzle.transform.rotation);
            leftHandAttack = false;
        }
        else
        {
            Instantiate<ParticleSystem>(bulletProjectile, muzzle2.transform.position, muzzle2.transform.rotation);
            leftHandAttack = true;
        }
        
    }
    public void StrongAttack()
    {
        Instantiate<ParticleSystem>(strongBulletProjectile, muzzle.transform.position, muzzle.transform.rotation);
    }
    public void GetEnemyState()
    {

    }

    public override (bool isInFly, int onGround, int inAir) NumberAction()
    {
        return (isInFly: true, onGround: -1, inAir: numberActionInAir);
    }
}
