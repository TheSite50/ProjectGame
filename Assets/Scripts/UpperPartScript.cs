using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpperPartScript : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 25f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform bulletParent;
    [SerializeField] float BulletDistance = 500f;
    [SerializeField] private PlayerInput playerInput;
    private Transform cameraTransform;
    private InputAction shootAction;
    [SerializeField] private Animator animator;
    void Awake()
    {
        cameraTransform = Camera.main.transform;
        shootAction = playerInput.actions["Fire"];
    }

    void Update()
    {
        //rotation
        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        //Debug.Log(targetRotation);
    }
    private void OnEnable()
    {
        shootAction.performed += _ => ShootWeapon();
    }
    private void OnDisable()
    {
        shootAction.performed -= _ => ShootWeapon();
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
