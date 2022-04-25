using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private GameObject _groundCheck;
    //[SerializeField] private GameObject bulletPrefab;
    //[SerializeField] private Transform barrelLocation;
    //[SerializeField] private Transform bulletParent;
    [SerializeField] float BulletDistance = 100f;
    
    [SerializeField] private PlayerInput playerInput;
    public Vector2 inputDirecion;                       //input direction
    [SerializeField] private Vector3 _movementDirection;

    public Vector3 move;                                //current movement direction

    [SerializeField] private float _rotationSpeed = 6;

    private Transform cameraTransform;


    private Animator animator;
    [SerializeField]private float _sprintSpeed = 1f;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;
    [SerializeField] float movementSpeed = 2.8f;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
        
    }
    private void Start()
    {
        if(CreatePlayerInGame.GetLegs())
        animator = CreatePlayerInGame.GetLegs().GetComponent<Animator>();
    }
    void Update()
    {
        //movement 
        HandleMovement();
        animator.SetBool("IsMoving", move != Vector3.zero);
    }

    private void HandleMovement()
    {
        move = new Vector3(inputDirecion.x, 0, inputDirecion.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0;
        rb.MovePosition(transform.position + movementSpeed * Time.deltaTime * move);
    }
    public void HandleSprint(InputAction.CallbackContext context) 
    {
        
    }

    public void Look(InputAction.CallbackContext context)
    {
        inputDirecion = speed * context.ReadValue<Vector2>();
    }
    //movement input
    public void Movement(InputAction.CallbackContext context)
    {
        inputDirecion = speed * context.ReadValue<Vector2>();
        //Debug.Log(context);
        //transform.rotation = Quaternion.Lerp(transform.rotation, CharacterRotation(), rotationSpeed * Time.deltaTime);
    }

    public Quaternion CharacterRotation()
    {
        return Quaternion.LookRotation(move);
    } 

    void BottomPartRotation()
    {
        if (move != Vector3.zero) 
        {
            Quaternion desiredRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
        }
    }
    
    private bool IsGrounded()
    {
        return _groundCheck.GetComponent<GroundCheck>().isGrounded;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        StartCoroutine(Dash());
    }
    IEnumerator Dash()
    {
        float startTime = Time.time;
        Debug.Log(Time.time < startTime + dashTime);
        while (Time.time < startTime + dashTime)
        {
            rb.MovePosition(dashSpeed * Time.deltaTime * move);
            yield return null;
        }
    }
    /*
private void OnEnable()
{
    shootAction.performed += _ => ShootWeapon();
}
private void OnDisable()
{
    shootAction.performed -= _ => ShootWeapon();
}
*/
    /*
public void ShootWeapon() {
    GameObject bullet = Instantiate(bulletPrefab, barrelLocation.position, Quaternion.identity, bulletParent);
    BulletLogic bulletLogic = bullet.GetComponent<BulletLogic>();
    //Debug.DrawRay(cameraTransform.position, cameraTransform.forward,Color.red, 10f);
    if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out desiredTarget, Mathf.Infinity))
    {

        bulletLogic.Target = desiredTarget.point;
        bulletLogic.Hit = true;
    }
    else
    {
        bulletLogic.Target = cameraTransform.position + cameraTransform.forward * BulletDistance;
        bulletLogic.Hit = false;
    }
}

*/
}

/*2 osobne obiekty 1 do ca³oœci 1 do górnej czêœci 1 do dolnej
 * górna rotuje za myszk¹
 * dolna zale¿nie od sterowania
 * top part
* =camerarotation 
*/
/*bottom part
* movedirection+camerarotation but update when moving
* ??? a/d rotate counterclockwise/clockwise and w and s move in rotated direction
*/
