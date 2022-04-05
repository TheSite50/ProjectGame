using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Boar :  EnemyAction
{
    [SerializeField] private ParticleSystem toxicProjectile;
    [SerializeField] private float distanceDetection;
    [SerializeField] private float distanceLowAttack;
    [SerializeField] private float distanceFarAttack;
    [SerializeField] private GameObject muzzle;
    private List<IAction> listEnemyAction;
    private bool isOnGround = false;
    private int numberAction = 0;
    private ActionState actionState;
    private GameObject player;
    private void Awake()
    {
        listEnemyAction = new List<IAction>();
        listEnemyAction.Add(new Patrol(distanceDetection));
        listEnemyAction.Add(new GoToPlayer(distanceDetection,distanceLowAttack,distanceFarAttack));
        listEnemyAction.Add(new AttackLongDistance(distanceFarAttack));
        listEnemyAction.Add(new AttackShortDistance(distanceLowAttack));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //idŸ do gracza
        //atakuj gracza
        //u¿yj umiejêtnoœci
        //zmieñ rodzej ataku
        if (isOnGround == true)
        {
            GetComponent<NavMeshAgent>().enabled = true; 
        }
        else
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }

        if (player != null&&isOnGround==true)
        {
            StartCoroutine(listEnemyAction[numberAction].Actions(player, this.gameObject, this));
            if (actionState == ActionState.actionComplete)
            {
                StopCoroutine(listEnemyAction[numberAction].Actions(player, this.gameObject, this));
                numberAction = numberAction < listEnemyAction.Count - 1 ? numberAction + 1 : listEnemyAction.Count - 1;
            }
            else if (actionState == ActionState.actionFail)
            {
                StopCoroutine(listEnemyAction[numberAction].Actions(player, this.gameObject, this));
                numberAction = 0;
            }
            else
            {
                StopCoroutine(listEnemyAction[numberAction].Actions(player, this.gameObject, this));
                print("false");
            }
            muzzle.transform.LookAt(player.transform);
        }

        
    }
    private void FixedUpdate()
    {
        isOnGround = Physics.CheckSphere(this.gameObject.transform.position, 9, 110, QueryTriggerInteraction.Ignore);//ground detect settings
        
    }

    public override void SetState(ActionState actionState)
    {
        this.actionState = actionState;
    }

    public void LongAttack()
    {
        Instantiate<ParticleSystem>(toxicProjectile, muzzle.transform.position, muzzle.transform.rotation) ;
    }

    public override void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    public override (float,float,float) GetDistance()
    {
        return (distanceDetection, distanceLowAttack, distanceFarAttack);
    }          
}              
