using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boar : EnemyProperties
{
    
    [SerializeField] private ParticleSystem toxicProjectile;
    [SerializeField] private ParticleSystem explosionProjectile;
    [SerializeField] private ParticleSystem chargeProjectile;
    [SerializeField] private GameObject muzzle;
    private RandomEnemySpawnBuff spawnBuff;
    private List<IAction> listEnemyActionOnGround;
    private List<IAction> listEnemyActionInAir;
    private bool isOnGround = false;
    private int numberActionOnGround = 0;
    private int numberActionInAir = 0;
    private ActionState actionState;
    private NavMeshAgent navMesh;
    private bool ILive = true;
    private bool iFly = false;
    private Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        spawnBuff = this.GetComponent<RandomEnemySpawnBuff>();
        navMesh = GetComponent<NavMeshAgent>();
        listEnemyActionOnGround = new List<IAction>();
        listEnemyActionOnGround.Add(new Patrol(distanceDetection));
        listEnemyActionOnGround.Add(new GoToPlayer(distanceDetection,distanceFarAttack));
        listEnemyActionOnGround.Add(new AttackLongDistance(distanceFarAttack));
        listEnemyActionOnGround.Add(new RunToPlayer(distanceDetection, distanceLowAttack, distanceFarAttack));
        listEnemyActionOnGround.Add(new AttackShortDistance(distanceLowAttack));


        listEnemyActionInAir = new List<IAction>();
        listEnemyActionInAir.Add(new FlyToPlayer(distanceDetection, distanceFarAttack,distanceLowAttack));
        listEnemyActionInAir.Add(new FlyAttack(distanceFarAttack));
        listEnemyActionInAir.Add(new Landing(distanceDetection, distanceFarAttack));
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
            
            iFly = false;
            
            navMesh.enabled = true; 
        }
        else
        {
            
            navMesh.enabled = false;
        }
        
        
        if(this.GetHp()<=70f&& this.GetHp() >= 50f)
        {
            
            iFly = true;
            rigidbody.useGravity = false;
            navMesh.enabled = false;
        }
        else if(this.GetHp() <= 50f)
        {
            numberActionInAir = 2;
            rigidbody.useGravity = true;
            
        }
        if(this.GetHp()<=0f&&ILive)
        {
            Death();
        }
        if (player != null && isOnGround == true && iFly==false&&ILive==true)
        {
            listEnemyActionOnGround[numberActionOnGround].Actions(player, this.gameObject, this);
            if (actionState == ActionState.actionComplete)
            {
                numberActionOnGround = numberActionOnGround < listEnemyActionOnGround.Count - 1 ? numberActionOnGround + 1 : listEnemyActionOnGround.Count - 1;
            }
            else if (actionState == ActionState.actionFail)
            {
                numberActionOnGround = 0;
            }
            else
            {
            }
            muzzle.transform.LookAt(player.transform.position);
        }
        else if(iFly == true)
        {
            listEnemyActionInAir[numberActionInAir].Actions(player, this.gameObject, this);
            if (actionState == ActionState.actionComplete)
            {
                numberActionInAir = numberActionInAir < listEnemyActionInAir.Count - 1 ? numberActionInAir + 1 : listEnemyActionInAir.Count - 1;
            }
            else if (actionState == ActionState.actionFail)
            {
                numberActionInAir = 0;
            }
            else
            {
            }
            muzzle.transform.LookAt(player.transform.position);
        }
        


        
    }
    private void FixedUpdate()
    {
        isOnGround = Physics.CheckSphere(this.gameObject.transform.position, 60, 110, QueryTriggerInteraction.Ignore);//ground detect settings
        
    }

    private void Death()
    {
        ILive = false;
        this.GetComponent<NavMeshAgent>().enabled = false;
        Instantiate<ParticleSystem>(explosionProjectile, this.transform.position, this.transform.rotation);
        spawnBuff.SpawnBuff();
        Portal.KillEnemy();
        Destroy(this.gameObject);
    }


    public override void SetState(ActionState actionState)
    {
        this.actionState = actionState;
    }

    public void LongAttack()
    {
        Instantiate<ParticleSystem>(toxicProjectile, muzzle.transform.position, muzzle.transform.rotation);
    }
    public void ChargeAttack()
    {
        Instantiate<ParticleSystem>(chargeProjectile, this.transform);
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
        return (isInFly: iFly, onGround: numberActionOnGround,inAir: numberActionInAir);
    }
}              
