using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boar : EnemyProperties
{
    
    [SerializeField] private ParticleSystem toxicProjectile;
    [SerializeField] private ParticleSystem explosionProjectile;
    [SerializeField] private ParticleSystem chargeProjectile;
    private RandomEnemySpawnBuff spawnBuff;
    private List<IAction> listEnemyActionOnGround;
    private List<IAction> listEnemyActionInAir;
    private bool isOnGround = false;
    private int numberActionOnGround = 0;
    private int numberActionInAir = 0;
    private ActionState actionState;

    private bool ILive = true;
    private bool iFly = false; 
    private void Awake()
    {
        spawnBuff = this.GetComponent<RandomEnemySpawnBuff>();
        listEnemyActionOnGround = new List<IAction>();
        listEnemyActionOnGround.Add(new Patrol(distanceDetection));
        listEnemyActionOnGround.Add(new GoToPlayer(distanceDetection,distanceLowAttack,distanceFarAttack));
        listEnemyActionOnGround.Add(new AttackLongDistance(distanceFarAttack));
        listEnemyActionOnGround.Add(new RunToPlayer(distanceDetection, distanceLowAttack, distanceFarAttack));
        listEnemyActionOnGround.Add(new AttackShortDistance(distanceLowAttack));


        listEnemyActionInAir = new List<IAction>();
        listEnemyActionInAir.Add(new Fly(distanceDetection, distanceFarAttack));
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
            GetComponent<NavMeshAgent>().enabled = true; 
        }
        else
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }
        //idŸ do gracza
        //atakuj gracza
        //u¿yj umiejêtnoœci
        //zmieñ rodzej ataku
        
        
        if(this.GetHp()<=70f&& this.GetHp() >= 50f)
        {
            
            iFly = true;
            
            GetComponent<NavMeshAgent>().enabled = false;
        }
        else if(this.GetHp() <= 50f)
        {
            numberActionInAir = 2;
            
        }
        if(this.GetHp()<=0f&&ILive)
        {
            Death();
        }
        if (player != null && isOnGround == true && iFly==false)
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
            muzzle.transform.LookAt(player.transform.position+Vector3.up*10f);
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
            muzzle.transform.LookAt(player.transform.position + Vector3.up * 5f);
        }
        


        
    }
    private void FixedUpdate()
    {
        isOnGround = Physics.CheckSphere(this.gameObject.transform.position, 9, 110, QueryTriggerInteraction.Ignore);//ground detect settings
        
    }

    private void Death()
    {
        this.GetComponent<NavMeshAgent>().enabled = false;
        Instantiate<ParticleSystem>(explosionProjectile, this.transform.position, this.transform.rotation);
        spawnBuff.SpawnBuff();
        Destroy(this.gameObject);
    }


    public override void SetState(ActionState actionState)
    {
        this.actionState = actionState;
    }

    public void LongAttack()
    {
        Instantiate<ParticleSystem>(toxicProjectile, muzzle.transform.position, muzzle.transform.rotation) ;
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
