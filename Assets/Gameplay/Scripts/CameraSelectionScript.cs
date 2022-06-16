using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
//used
public class CameraSelectionScript : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction aimAction;
    private CinemachineVirtualCamera virtualCamera;
    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];
    }
    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }
    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }
    private void StartAim() {
        virtualCamera.Priority += 2;
    }
    private void CancelAim() {
        virtualCamera.Priority -= 2;
    }
}
