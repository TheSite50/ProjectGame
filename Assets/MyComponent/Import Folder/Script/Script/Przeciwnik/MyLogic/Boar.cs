using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Boar : MonoBehaviour,IEnemyAction
{

    [SerializeField] GameObject player;
    [SerializeField] float distance;
    [SerializeField] float distanceLow;
    [SerializeField] float distanceFar;
    private List<IAction> listEnemyAction;
    private int numberAction = 0;
    private ActionState actionState;
    private void Awake()
    {
        listEnemyAction = new List<IAction>();
        listEnemyAction.Add(new Patrol());
        listEnemyAction.Add(new GoToPlayer());
        listEnemyAction.Add(new AttackShortDistance());
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
        StartCoroutine(listEnemyAction[numberAction].Actions(player, this.GetComponent<NavMeshAgent>(), distance, distanceLow, distanceFar, this, this.GetComponent<Animator>()));
        if (actionState==ActionState.actionComplete)
        {
            StopCoroutine(listEnemyAction[numberAction].Actions(player, this.GetComponent<NavMeshAgent>(), distance, distanceLow, distanceFar, this, this.GetComponent<Animator>()));
            numberAction = numberAction < listEnemyAction.Count-1?numberAction+1 : listEnemyAction.Count-1;
        }
        else if(actionState == ActionState.actionFail)
        {
            StopCoroutine(listEnemyAction[numberAction].Actions(player, this.GetComponent<NavMeshAgent>(), distance, distanceLow, distanceFar, this, this.GetComponent<Animator>()));
            numberAction = 0;
        }
        else
        {
        }
    }

    public void SetState(ActionState actionState)
    {
        this.actionState = actionState;
    }
}
