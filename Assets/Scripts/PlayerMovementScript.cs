using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

//used
public class PlayerMovementScript : MonoBehaviour
{
    private InputScript _input;
    private PlayerInput _playerInput;
    public bool _isPlayerBusy { get; set; }

    [SerializeField] private float _rotationSpeed = 6;
    [SerializeField] float MoveSpeed;
    //private Rigidbody _rb;
    private CharacterController player;
    //[SerializeField] private GroundCheck _groundCheck;

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
    [SerializeField] private GameObject hull;
    private bool IsCurrentDeviceMouse => _playerInput.currentControlScheme == "KeyboardMouse";

    [SerializeField] private weaponSystem _weaponRight;
    [SerializeField] private weaponSystem _weaponLeft;
    [SerializeField]private float gravityStrength = 9.81f;

    #region Unity Functions
    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        _playerInput = GetComponent<PlayerInput>();
        _input = GetComponent<InputScript>();
        //_rb = GetComponent<Rigidbody>();
        player = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {

        if (player.isGrounded)
        {
            AutoRotationControlInDesiredDirection();
        }
        if (!player.isGrounded)
        {
            ApplyGravity();
        }

    }

    private void ApplyGravity()
    {
       
        player.Move(-transform.up.normalized * gravityStrength*Time.deltaTime);
    }

    private void LateUpdate()
    {   
        //Debug.Log(_input.shootLPM + " PMS");
        Shooting();
        CameraRotation();

    }
    void Shooting()
    {
        if (!_isPlayerBusy)
        {
            _weaponRight.TryToShootNextBullet(_input.shootLPM);
            _weaponLeft.TryToShootNextBullet(_input.shootRPM);
        }
    }
    void Reloading()
    {
        if (!_isPlayerBusy)
        {
            if (_weaponRight is IReloadable) 
            {
                if (_weaponRight.CurrentAmmoInMag != _weaponRight.MaxAmmo)
                {
                    //(IReloadable)_weapon.Reload(_input.reload);
                    IReloadable myWeapon = _weaponRight as IReloadable;
                    myWeapon.Reload();

                }
            }
            if (_weaponLeft)
            {
                if (_weaponLeft is IReloadable)
                {
                    if (_weaponLeft.CurrentAmmoInMag != _weaponRight.MaxAmmo)
                    {
                        //(IReloadable)_weapon.Reload(_input.reload);
                        IReloadable myWeapon = _weaponRight as IReloadable;
                        myWeapon.Reload();
                    }
                }
            }
        }
    }

    #endregion
    #region Mech Controls
    public void AutoRotationControlInDesiredDirection()
    {
        //Debug.Log(_input.move);   
        //Vector3 desiredDirection = new Vector3(move.x, 0, move.y);
        Vector3 desiredDirection = new Vector3(_input.move.x, 0, _input.move.y);
        desiredDirection = desiredDirection.x * cameraTransform.right.normalized + desiredDirection.z * cameraTransform.forward.normalized;
        desiredDirection.y = 0;

        //_rb.MoveRotation(Quaternion.Euler(Vector3.up * Vector3.Lerp(Vector3, desiredDirection-transform.forward, _rotationSpeed * Time.deltaTime)));
        transform.forward = Vector3.Lerp(transform.forward, desiredDirection, _rotationSpeed * Time.deltaTime);
        //transform.forward = Vector3.Lerp(transform.forward, desiredDirection, _rotationSpeed * Time.deltaTime);
        if (Vector3.Dot(transform.forward, desiredDirection) > 0.7f)
        {
            player.Move(MoveSpeed * desiredDirection.normalized);
            //_rb.AddForce(500 * MoveSpeed * desiredDirection.normalized);
            //_rb.MovePosition(transform.position + desiredDirection.normalized * 25 * MoveSpeed * Time.deltaTime);
        }

    }
    public void CameraRotation()
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
    void Stomp() { }
    #endregion
}
