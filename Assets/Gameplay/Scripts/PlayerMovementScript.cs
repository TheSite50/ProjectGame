using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    private InputScript _input;
    private PlayerInput _playerInput;

    
    [SerializeField] private float _rotationSpeed = 6;
    [SerializeField] float MoveSpeed;
    private Rigidbody _rb;

    [Header("Camera")]
    private Transform cameraTransform;
    [SerializeField] private float _cameraSensitivity = 300; //lookspeed
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    [SerializeField] private float TopClamp = 70.0f;
    [SerializeField] private float BottomClamp = -30.0f;
    [SerializeField] private GameObject CinemachineCameraTarget;
    private float CameraAngleOverride = 0.0f;
    private const float _threshold = 0.00001f;
    [SerializeField] private bool LockCameraPosition = false;
    //[SerializeField] private GameObject hull;
    private GameObject hull;
    private bool IsCurrentDeviceMouse => _playerInput.currentControlScheme == "KeyboardMouse";

    [Header("Stomp")]
    [SerializeField] GameObject StompParticles;
    [SerializeField] float stompCooldown = 5f;
    private bool stompActive = false;
    [SerializeField] float stompRange = 40f;
    [SerializeField] float stompDamage = 1000f;
    [SerializeField] LinePath _linepath;

    //[SerializeField]GameObject x;

    #region Unity Functions
    private void Awake()
    {
        hull = CreatePlayerInGame.GetTorso();
        cameraTransform = Camera.main.transform;
        _playerInput = GetComponent<PlayerInput>();
        _input = GetComponent<InputScript>();
        _rb = GetComponent<Rigidbody>();
        _linepath = GetComponent<LinePath>();
    }

    private void Start()
    {
        
    }


    private void FixedUpdate()
    {
        AutoRotationControlInDesiredDirection();
    }
    private void LateUpdate()
    {
        // HandleTurretRotation();
        //LookDirection();
        Path();
        Stomp();
        CameraRotation();
        
    }
   /* private void Update()
    {
        if (_input.jump == true)
            aabbcc();
        Debug.Log("working");
    }*/
    #endregion
    #region Mech Controls
    void AutoRotationControlInDesiredDirection()
    {
        Vector3 desiredDirection = new Vector3(_input.move.x, 0, _input.move.y);
        desiredDirection = desiredDirection.x * cameraTransform.right.normalized + desiredDirection.z * cameraTransform.forward.normalized;
        desiredDirection.y = 0;

        //_rb.MoveRotation(Quaternion.Euler(Vector3.up * Vector3.Lerp(Vector3, desiredDirection-transform.forward, _rotationSpeed * Time.deltaTime)));
        transform.forward = Vector3.Lerp(transform.forward, desiredDirection, _rotationSpeed * Time.deltaTime);
        //transform.forward = Vector3.Lerp(transform.forward, desiredDirection, _rotationSpeed * Time.deltaTime);
        if (Vector3.Dot(transform.forward, desiredDirection) > 0.7f)
        {
            _rb.AddForce(500 * MoveSpeed * desiredDirection.normalized);
            //_rb.MovePosition(transform.position + desiredDirection.normalized * 25 * MoveSpeed * Time.deltaTime);
        }

    }
    private void CameraRotation()
    {
        // if there is an input and camera position is not fixed
        if (_input.look.sqrMagnitude >= _threshold && !LockCameraPosition)
        {
            float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;
            _cinemachineTargetYaw += 3 * _input.look.x * deltaTimeMultiplier * _cameraSensitivity;
            _cinemachineTargetPitch += 3 * _input.look.y * deltaTimeMultiplier * _cameraSensitivity;
        }

        // clamp our rotations so our values are limited 360 degrees
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // Cinemachine will follow this target
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride, _cinemachineTargetYaw, 0.0f);
    }
    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
    #endregion
    #region Special Moves
    void Dash() { }
    public void Stomp()
    {
        if(_input.stomp)
        { 
        if (stompActive == false)
        {
            stompActive = true;
            float startTime = Time.time;
            Debug.Log(Time.time < startTime + stompCooldown);


            if (Time.time < startTime + stompCooldown)
            {
                CheckForEnemies();
                StompParticles.SetActive(true);
                Invoke("StopParticles", stompCooldown);
            }

        }
        }



    }

    void StopParticles()
    {
        StompParticles.SetActive(false);
        stompActive = false;
    }

    public void CheckForEnemies()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, stompRange);
        foreach (Collider c in colliders)
        {
            if (c.GetComponent<EnemyProperties>())
            {
                c.GetComponent<EnemyProperties>().SetHp(c.GetComponent<EnemyProperties>().GetHp() - stompDamage);
            }
        }
        
    }

    public void Path()
    {
        if(_input.path)
        {
            _linepath.getPath();
        }
    }
    #endregion
}
