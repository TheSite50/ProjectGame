using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptBackup : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform bulletParent;
    [SerializeField] float BulletDistance = 100f;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float gravity = 9.81f;
    private Transform cameraTransform;
    Vector2 direction;
    private InputAction shootAction;
    [SerializeField] private Animator animator;
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
        shootAction = playerInput.actions["Fire"];

    }

    void Update()
    {
        //movement
        Vector3 move = new Vector3(direction.x, 0, direction.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0;

        //rb.velocity = move;
        rb.MovePosition(transform.position + 2.8f * Time.deltaTime * move);

        //movementAnimation
        animator.SetFloat("MovementSpeed", direction.y);
        Debug.Log(direction.y);

        //rotation
        //     Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        //     transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed*Time.deltaTime);
        //     Debug.Log(IsGrounded());
    }
    private void OnEnable()
    {
        shootAction.performed += _ => ShootWeapon();
    }
    private void OnDisable()
    {
        shootAction.performed -= _ => ShootWeapon();
    }
    //movement input
    public void Movement(InputAction.CallbackContext context)
    {
        direction = speed * context.ReadValue<Vector2>();
    }

    public void CharacterRotation(InputAction.CallbackContext context)//to implement /////////////////////////////////////////////
    {

        Debug.Log(context);

    }
    //private void ApplyGravity() {
    //    if (!IsGrounded()) {  }
    //}
    private bool IsGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }
    public void ShootWeapon()
    {
        GameObject bullet = Instantiate(bulletPrefab, barrelLocation.position, Quaternion.identity, bulletParent);
        BulletLogic bulletLogic = bullet.GetComponent<BulletLogic>();
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit desiredTarget, Mathf.Infinity))
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
