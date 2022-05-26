
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : BossProperties
{
    [SerializeField] private ParticleSystem ball;
    [SerializeField] private ParticleSystem ballAttack;
    [SerializeField] private GameObject muzzle;
    private ParticleSystem ballSkill;
    private Dictionary<int,IAction> listEnemyActionOnGround;
    private bool isOnGround = false;
    private int numberActionOnGround = 0;
    private ActionState actionState;
    private RandomEnemySpawnBuff spawnBuff;
    private NavMeshAgent navMesh;
    private bool ILive = true;
    private bool useSkill = false;
    private void Awake()
    {
        spawnBuff = this.GetComponent<RandomEnemySpawnBuff>();
        navMesh = GetComponent<NavMeshAgent>();
        listEnemyActionOnGround = new Dictionary<int, IAction>();
        listEnemyActionOnGround.Add(0, new Patrol(distanceDetection));
        listEnemyActionOnGround.Add(1, new BossGoToPlayer(distanceDetection, distanceLowAttack, distanceFarAttack));
        listEnemyActionOnGround.Add(2, new BossAttack(distanceLowAttack));
        //listEnemyActionOnGround.Add(3, new BossAttack(distanceLowAttack));
        listEnemyActionOnGround.Add(5, new UseSkill(distanceFarAttack, distanceDetection));

        //listEnemyActionOnGround.Add(new UseSkill());
    }
    public override (bool isInFly, int onGround, int inAir) NumberAction()
    {
        
        return (false, numberActionOnGround, -1);
    }

    public override void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    public override void SetState(ActionState actionState)
    {
        this.actionState = actionState;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderHp.value = this.GetHp() / 1000f;

        if (Vector3.Distance(player.transform.position, this.transform.position) > distanceFarAttack && Vector3.Distance(player.transform.position, this.transform.position) < distanceDetection && useSkill == false)
        {
            useSkill = true;
            if (useSkill == true)
            {
                numberActionOnGround = 5;
                print("Hello");
            }
        }

        //listEnemyActionOnGround[numberActionOnGround].Actions(player, this.gameObject, this);
        if (player != null && isOnGround == true)
        {
            if (numberActionOnGround == 3)
            {
                listEnemyActionOnGround[2].Actions(player, this.gameObject, this);
            }
            else
            {
                if (numberActionOnGround == 5)
                    print("World");
                listEnemyActionOnGround[numberActionOnGround].Actions(player, this.gameObject, this);
            }
            if (actionState == ActionState.actionComplete)
            {
                numberActionOnGround = numberActionOnGround < 2 ? numberActionOnGround + 1 : 2;
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
    public void CreateThisSkill()
    {
        ballSkill = Instantiate<ParticleSystem>(ball, muzzle.transform);
        
    }
    private void UseThisSkill()
    {
        Destroy(ballSkill.gameObject);
        muzzle.transform.LookAt(player.transform);
        Instantiate<ParticleSystem>(ball, muzzle.transform.position, muzzle.transform.rotation);
        Instantiate<ParticleSystem>(ballAttack, muzzle.transform.position, muzzle.transform.rotation);
    }

    private void FixedUpdate()
    {
        isOnGround = Physics.CheckSphere(this.gameObject.transform.position, 9, 110, QueryTriggerInteraction.Ignore);//ground detect settings

    }
    public void SetActionNumber(int actionNumber)
    {
        this.numberActionOnGround = actionNumber;
    }
}