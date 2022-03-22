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
    Quaternion _turretRotation;//gdzie jest celownik
    public Vector3 hitLocation;
    void Awake()
    {
        cameraTransform = Camera.main.transform;
        shootAction = playerInput.actions["Fire"];
    }

    void Update()
    {
        Debug.Log(hitLocation);
        //rotation
        Quaternion targetRotation = Quaternion.Euler(cameraTransform.eulerAngles.x, cameraTransform.eulerAngles.y, 0);
        _turretRotation = Quaternion.Lerp(_turretRotation,targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = _turretRotation;
        //transform.LookAt(_turretRotation.eulerAngles);
        //transform.rotation = Quaternion.(transform.rotation, _turretRotation, rotationSpeed * Time.deltaTime);
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
        if (Physics.Raycast(barrelLocation.position, transform.forward, out RaycastHit desiredTarget, Mathf.Infinity))//strzela przed siebie dodac rotacje do minigunów by obraca³y siê w strone kursora,dodac kursor pokazujacy gdzie dokladnie teraz poleci pocisk
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
