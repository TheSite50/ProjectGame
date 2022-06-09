using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    [Header("Camera")]
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
    [SerializeField] private InputScript _input;
    [SerializeField] private PlayerInput _playerInput;
    private bool IsCurrentDeviceMouse => _playerInput.currentControlScheme == "KeyboardMouse";
    private void LateUpdate()
    {
        CameraRotation();
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

}
