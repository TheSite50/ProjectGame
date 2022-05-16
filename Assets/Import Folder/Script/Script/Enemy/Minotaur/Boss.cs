using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : BossProperties
{
    [SerializeField] private GameObject[] tabeleSkillElements;
    private List<IAction> listEnemyActionOnGround;
    private bool isOnGround = false;
    private int numberActionOnGround = 0;
    private ActionState actionState;
    private RandomEnemySpawnBuff spawnBuff;
    private NavMeshAgent navMesh;
    private bool ILive = true;
    private void Awake()
    {
        spawnBuff = this.GetComponent<RandomEnemySpawnBuff>();
        navMesh = GetComponent<NavMeshAgent>();
        listEnemyActionOnGround = new List<IAction>();
        listEnemyActionOnGround.Add(new Patrol(distanceDetection));
        listEnemyActionOnGround.Add(new BossGoToPlayer(distanceDetection, distanceLowAttack));
        listEnemyActionOnGround.Add(new BossAttack(distanceLowAttack));
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

        if (numberActionOnGround==5)
        {
            StartCoroutine(Use());
            return;
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
    IEnumerator Use()
    {
        foreach(GameObject element in tabeleSkillElements)
        {
            Vector3.Lerp(element.transform.position, new Vector3(element.transform.position.x, element.transform.position.y + 20f, element.transform.position.z), Time.deltaTime);
        }
        this.numberActionOnGround = 0;
        yield return null;
    }
    private void UseThisSkill()
    {
        this.numberActionOnGround = 5;
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
