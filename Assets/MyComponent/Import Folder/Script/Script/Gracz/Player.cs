using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Movement playerMovement;
    private Rotation playerRotation;
    private bool isOnGround=false;
    private GameObject leftWeapon;
    private GameObject rightWeapon;
    private GameObject accesory;
    //private GameObject leftWeaponMuzzle;
    //private GameObject rightWeaponMuzzle;
    private GameObject horizontalRotation;
    private GameObject verticalRotation;

    [Header("Player Value")] 
    [SerializeField] private float playerSpeed = 0.01f;
    [SerializeField] private float mouseSpeed = 10f;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject viewPoint;
    //[SerializeField]private GameObject leftWeaponMuzzle;
    //[SerializeField]private GameObject rightWeaponMuzzle;
    //[SerializeField] private GameObject verticalRotation;
    //[SerializeField] Animator gunAnimator;
    
    private void Start()
    {
        if(CreatePlayerInGame.GetWeaponLeft())
            leftWeapon = CreatePlayerInGame.GetWeaponLeft();
        else
        {
            leftWeapon = CreatePlayerInGame.GetArm();
        }
        if (CreatePlayerInGame.GetWeaponRight() != null)
            rightWeapon = CreatePlayerInGame.GetWeaponRight();
        else
        {
            rightWeapon = CreatePlayerInGame.GetArm();
        }
        accesory = CreatePlayerInGame.GetAccesories();
        horizontalRotation = CreatePlayerInGame.GetTorso();
        verticalRotation = viewPoint;
        
        //leftWeaponMuzzle = PlayerBuild.GetWeaponLeft() != null ? PlayerBuild.GetWeaponLeft().GetComponent<IWeapon>().WeaponMuzzle()[0] : PlayerBuild.GetArm().GetComponent<IWeapon>().WeaponMuzzle()[0];
        //rightWeaponMuzzle = PlayerBuild.GetWeaponRight() != null ? PlayerBuild.GetWeaponRight().GetComponent<IWeapon>().WeaponMuzzle()[0] : PlayerBuild.GetArm().GetComponent<IWeapon>().WeaponMuzzle()[1];
        playerMovement = ScriptableObject.CreateInstance<Movement>();
        playerRotation = ScriptableObject.CreateInstance<Rotation>();
        
    }
    IEnumerator UseAccesory()
    {
        //accesory.GetComponent<IAccesories>().UseSuperPower();
        yield return null;
    }
    IEnumerator ShootLeftWeapeon()
    {
        leftWeapon.GetComponent<IWeapon>().Attack(leftWeapon.GetComponent<IWeapon>().WeaponMuzzle()[0]);
        //gunAnimator.SetBool("Shoot", true);
        yield return null;
    }
    IEnumerator ShootRightWeapeon()
    {
        rightWeapon.GetComponent<IWeapon>().Attack(rightWeapon.GetComponent<IWeapon>().WeaponMuzzle()[1]);
        //gunAnimator.SetBool("Shoot", true);
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        playerMovement.ActorMovement(this.gameObject, horizontalRotation.transform.rotation, Camera.main, playerSpeed, playerAnimator, isOnGround);
        playerRotation.PlayerRotation(verticalRotation, horizontalRotation, Camera.main, mouseSpeed);
        playerRotation.WeaponRotation(leftWeapon, rightWeapon, Camera.main);   
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(ShootLeftWeapeon());
            if (Input.GetKey(KeyCode.Mouse1))
            {
                StartCoroutine(ShootRightWeapeon());
            }
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            StartCoroutine(ShootRightWeapeon());
            if (Input.GetKey(KeyCode.Mouse0))
            {
                StartCoroutine(ShootLeftWeapeon());
            }
        }
        if (Input.GetKey(KeyCode.Mouse2))
        {
            StartCoroutine(UseAccesory());
        }

    }
    private void FixedUpdate()
    {
        isOnGround = Physics.CheckSphere(this.gameObject.transform.position, 20, 110, QueryTriggerInteraction.Ignore);//ground detect settings

    }


}
