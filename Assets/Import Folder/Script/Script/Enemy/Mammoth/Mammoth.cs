using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mammoth : EnemyProperties
{
    [SerializeField] private ParticleSystem fireProjectile;
    private RandomEnemySpawnBuff spawnBuff;
    private List<IAction> listEnemyAction;
    private bool isOnGround = false;
    private int numberAction = 0;
    private ActionState actionState;
    private float deathTime = 0;
    [SerializeField] private GameObject muzzle;

    private bool iLive = true;
    private Rigidbody mammothRigidbody;
    private NavMeshAgent mammothNavMeshAgent;
    private Animator mammothAnimator;

    
    void Awake()
    {
        mammothAnimator = this.GetComponent<Animator>();
        mammothNavMeshAgent = this.GetComponent<NavMeshAgent>();
        mammothRigidbody = this.GetComponent<Rigidbody>();
        mammothRigidbody = this.GetComponent<Rigidbody>();
        spawnBuff = this.GetComponent<RandomEnemySpawnBuff>();
        listEnemyAction = new List<IAction>();
        listEnemyAction.Add(new Patrol(distanceDetection));
        listEnemyAction.Add(new GoToPlayer(distanceDetection, distanceFarAttack));
        listEnemyAction.Add(new AttackInMove(distanceDetection, distanceLowAttack, distanceFarAttack));
        listEnemyAction.Add(new AttackShortDistance(distanceLowAttack));
    }

    

    // Update is called once per frame
    void Update()
    {
        sliderHp.value = this.GetHp() / 1000f;

        if (this.GetHp() <= 0f && iLive==true)
        {
            Death();
        }
        if (iLive==false)
        {
            deathTime += Time.deltaTime;
        }
        if(deathTime>=2)
        {
            Destroy(this.gameObject);
        }
        //idŸ do gracza
        //atakuj gracza
        //u¿yj umiejêtnoœci
        //zmieñ rodzej ataku
        if(iLive==true)
        {
        if (isOnGround == true)
        {
            GetComponent<NavMeshAgent>().enabled = true;
        }
        else
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }
       
        if (player != null && isOnGround == true )
        {

            listEnemyAction[numberAction].Actions(player, this.gameObject, this);
            if (actionState == ActionState.actionComplete)
            {
                numberAction = numberAction < listEnemyAction.Count - 1 ? numberAction+ 1 : listEnemyAction.Count - 1;
            }
            else if (actionState == ActionState.actionFail)
            {
                numberAction = 0;
            }
            else
            {
               
            }

            muzzle.transform.LookAt(player.transform);
        } 
        }
    }

    private void Death()
    {
        mammothAnimator.SetTrigger("Death");
        mammothNavMeshAgent.enabled = false;
        mammothRigidbody.useGravity = false;
        mammothRigidbody.isKinematic = true;
        spawnBuff.SpawnBuff();
        Portal.KillEnemy();
        iLive = false;
        deathTime = 0;
    }

    private void FixedUpdate()
    {
        isOnGround = Physics.CheckSphere(this.gameObject.transform.position, 40, 110, QueryTriggerInteraction.Ignore);//ground detect settings
    }
    public void FireAttack()
    {
        Instantiate<ParticleSystem>(fireProjectile, muzzle.transform.position,muzzle.transform.rotation);
    }
    public override void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    public override void SetState(ActionState actionState)
    {
        this.actionState = actionState;
    }

    public override (bool isInFly, int onGround, int inAir) NumberAction()
    {
        return (false, numberAction, -1);
    }
}