using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    [Header("")]
    private Rigidbody rb;
    
    
    
    
    
    
    [Header("Systems")]
    [SerializeField] private InputScript _input;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Animator animator;
    public Vector2 inputDirecion;                       //input direction
    private bool IsCurrentDeviceMouse => _playerInput.currentControlScheme == "KeyboardMouse";

    [Header("Movement")]
    
    [SerializeField] private GameObject _groundCheck;
    [SerializeField] private Vector3 _movementDirection;//current movement directions
    public Vector3 move;
    [SerializeField] float MoveSpeed = 2.8f;
    [SerializeField] float SprintSpeed = 6f;
    public float RotationSmoothTime = 0.12f;
    public float SpeedChangeRate = 10.0f;
    private float _speed;
    private float _animationBlend;
    private float _targetRotation = 0.0f;
    private float _rotationVelocity;
    private float _verticalVelocity;




    [Header("Camera")]
    private Transform cameraTransform;
    [SerializeField] private float _rotationSpeed = 6;
    [SerializeField] private float _cameraSensitivity = 50; //lookspeed
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    public float TopClamp = 70.0f;
    public float BottomClamp = -30.0f;
    public GameObject CinemachineCameraTarget;
    public float CameraAngleOverride = 0.0f;
    private const float _threshold = 0.00001f;

    public bool LockCameraPosition = false;



    [Header("Shooting")]
    [SerializeField] private Transform bulletParent;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private GameObject bulletPrefab;

    
   
                                    

    

    


    
    [SerializeField]private float _sprintSpeed = 1f;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;
    

    void Awake()
    {
        
        _playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
        _input = GetComponent<InputScript>();
    }

    void Update()
    {
        //movement 
        
        animator.SetBool("IsMoving", _input.move!=Vector2.zero);
    }
    private void LateUpdate()
    {
        CameraRotation();
        //HandleMovement();
        //PlayerControlsRotationMovementSetting();
        AutoRotationControlInDesiredDirection();
        //Move();
    }

    private void HandleMovement()
    {
       // float targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed;
        //if (_input.move == Vector2.zero) targetSpeed = 0.0f;
        Vector3 desiredMove = new Vector3(_input.move.x, 0, _input.move.y);

        desiredMove = desiredMove.x * cameraTransform.right.normalized + desiredMove.z * cameraTransform.forward.normalized;
        desiredMove.y = 0;
        Debug.Log(desiredMove);
        move = Vector3.Lerp(move, desiredMove, _rotationSpeed);

        rb.MovePosition(transform.position + MoveSpeed * Time.deltaTime * move*50);
        transform.forward = Vector3.Lerp(transform.forward, move, _rotationSpeed);
    }
    void PlayerControlsRotationMovementSetting() 
    {
        Vector3 desiredMove = new Vector3(0, _input.move.x * _rotationSpeed, 0);
        Quaternion addRotation = transform.rotation * Quaternion.Euler(desiredMove);
        rb.MoveRotation(addRotation);
        rb.MovePosition(transform.position + _input.move.y * 25 * MoveSpeed * Time.deltaTime * transform.forward);
        Debug.Log(1000*transform.forward * _input.move.y * MoveSpeed * Time.deltaTime);
    }
    void AutoRotationControlInDesiredDirection() 
    {
        Vector3 desiredDirection = new Vector3(_input.move.x, 0, _input.move.y);
        desiredDirection = desiredDirection.x * cameraTransform.right.normalized + desiredDirection.z * cameraTransform.forward.normalized;
        desiredDirection.y = 0;
        Debug.Log(desiredDirection);
        //transform.forward = Vector3.SmoothDamp(transform.forward, desiredDirection.normalized, ref move, 0.5f);
        transform.forward = Vector3.Lerp(transform.forward, desiredDirection, _rotationSpeed * Time.deltaTime);
        if (Vector3.Dot(transform.forward, desiredDirection) > 0.7f )
        {//to fix doesn't move in this direction stnads still and doesnt move
            rb.MovePosition(transform.position + desiredDirection.normalized * 25 * MoveSpeed * Time.deltaTime);
        }

    }


    private void Move()
    {
        
        float targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed;
        if (_input.move == Vector2.zero) targetSpeed = 0.0f;
        float currentHorizontalSpeed = new Vector3(_input.move.x, 0.0f, _input.move.y).magnitude;
        
        float speedOffset = 0.1f;
        float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;
        Debug.Log(currentHorizontalSpeed);
        Debug.Log(targetSpeed);
        if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
        {

            _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * SpeedChangeRate);


            _speed = Mathf.Round(_speed * 1000f) / 1000f;
        }
        else
        {
            _speed = targetSpeed;
        }
        

        Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

        if (_input.move != Vector2.zero)
        {
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cameraTransform.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, RotationSmoothTime);

            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }


        Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

        rb.MovePosition(targetDirection.normalized * (_speed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
    }

    private void CameraRotation()
    {
        // if there is an input and camera position is not fixed
        if (_input.look.sqrMagnitude >= _threshold && !LockCameraPosition)
        {
            float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;
            _cinemachineTargetYaw +=3* _input.look.x * deltaTimeMultiplier * _cameraSensitivity;
            _cinemachineTargetPitch +=3* _input.look.y * deltaTimeMultiplier * _cameraSensitivity;
        }

        // clamp our rotations so our values are limited 360 degrees
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // Cinemachine will follow this target
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride, _cinemachineTargetYaw, 0.0f);
    }
    ///================================================
    ///

    public void HandleSprint(InputAction.CallbackContext context) 
    {
        
    }
    public void Movement(InputAction.CallbackContext context)
    {
        inputDirecion = _cameraSensitivity * context.ReadValue<Vector2>();
        //Debug.Log(context);   
        //transform.rotation = Quaternion.Lerp(transform.rotation, CharacterRotation(), rotationSpeed * Time.deltaTime);
    }
    public void Dash(InputAction.CallbackContext context)
    {
        StartCoroutine(Dash());
    }
    ///================================================
    ///
    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    //movement input


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
