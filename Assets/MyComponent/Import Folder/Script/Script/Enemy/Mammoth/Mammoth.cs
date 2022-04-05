using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mammoth : EnemyAction
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

    public override (float, float, float) GetDistance()
    {
        return (distanceDetection, distanceLowAttack, distanceFarAttack);
    }

    public override void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    public override void SetState(ActionState actionState)
    {
        this.actionState = actionState;
    }
    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }
}