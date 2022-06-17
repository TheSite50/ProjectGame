using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ice_Enemy : EnemyProperties
{
    private RandomEnemySpawnBuff spawnBuff;
    private List<IAction> listEnemyActionOnGround;
    private bool isOnGround = false;
    private int numberActionOnGround = 0;
    private ActionState actionState;
    private NavMeshAgent navMesh;
    private bool ILive = true;
    private void Awake()
    {
        spawnBuff = this.GetComponent<RandomEnemySpawnBuff>();
        navMesh = GetComponent<NavMeshAgent>();
        listEnemyActionOnGround = new List<IAction>();
        listEnemyActionOnGround.Add(new Patrol(distanceDetection));
        listEnemyActionOnGround.Add(new GoToPlayer(distanceDetection, distanceFarAttack));
        //listEnemyActionOnGround.Add(new AttackLongDistance(distanceFarAttack));
        //listEnemyActionOnGround.Add(new RunToPlayer(distanceDetection, distanceLowAttack, distanceFarAttack));
        listEnemyActionOnGround.Add(new AttackShortDistance(distanceLowAttack));
        listEnemyActionOnGround.Add(new AttackShortDistance(distanceLowAttack));

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sliderHp.value = this.GetHp() / 100f;
        if (isOnGround == true)
        {
            navMesh.enabled = true;
        }
        else
        {
            navMesh.enabled = false;
        }
        if (this.GetHp() <= 0)
        {
            Death();
        }
        if (player != null && isOnGround == true&&ILive==true )
        {
            listEnemyActionOnGround[numberActionOnGround].Actions(player, this.gameObject, this);
            if (actionState == ActionState.actionComplete)
            {
                numberActionOnGround = numberActionOnGround < listEnemyActionOnGround.Count - 1 ? numberActionOnGround + 1 : 2;
            }
            else if (actionState == ActionState.actionFail)
            {
                numberActionOnGround = 0;
            }
            else
            {
            }
        }

    }
    private void FixedUpdate()
    {
        isOnGround = Physics.CheckSphere(this.gameObject.transform.position, 30, 110, QueryTriggerInteraction.Ignore);//ground detect settings

    }

    private void Death()
    {
        ILive = false;
        this.GetComponent<Ice_EnemyAnimationMenage>().enabled = false;
        this.GetComponent<NavMeshAgent>().enabled = false;
        spawnBuff.SpawnBuff();
        this.GetComponent<Animator>().SetBool("Death", true);
        this.GetComponent<Ice_Enemy>().enabled = false;
        Portal.KillEnemy();
    }


    public override void SetState(ActionState actionState)
    {
        this.actionState = actionState;
    }

    public void LongAttack()
    {
        //Instantiate<ParticleSystem>(toxicProjectile, muzzle.transform.position, muzzle.transform.rotation);
    }
    public void ChargeAttack()
    {
        //Instantiate<ParticleSystem>(chargeProjectile, this.transform);
    }
    public override void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    public void GetEnemyState()
    {

    }

    public override (bool isInFly, int onGround, int inAir) NumberAction()
    {
        return (isInFly: false, onGround: numberActionOnGround, inAir: -1);
    }
}
