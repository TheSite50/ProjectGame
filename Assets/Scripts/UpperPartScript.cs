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
    private Vector3 _lookAtPoint;
    [SerializeField] float _weaponRange = 100f;
    [SerializeField] private PlayerInput playerInput;
    private Transform cameraTransform;
    private InputAction shootAction;
    [SerializeField] private Animator animator;
    public Vector3 _desiredShootLocation;//gdzie jest celownik
    RaycastHit hitLocation;
    bool raycast;

    void Awake()
    {
        cameraTransform = Camera.main.transform;
        shootAction = playerInput.actions["Fire"];
    }

    void Update()
    {
        HandleTurretRotation();
        WhereIsShooting();
        BarrelOffset();
    }

    void BarrelOffset() 
    {
        raycast = Physics.Raycast(cameraTransform.position, transform.forward, out RaycastHit lookLocation, Mathf.Infinity);
        if (raycast)
        {
            _lookAtPoint = lookLocation.point;
        }
        else
        {
            _lookAtPoint = barrelLocation.position + barrelLocation.forward * _weaponRange;
        }
        barrelLocation.LookAt(lookLocation.transform);

        Debug.DrawRay(barrelLocation.position, transform.forward*500, Color.red);
        Debug.Log(barrelLocation.rotation);
    }
    private void WhereIsShooting()
    {
        raycast = Physics.Raycast(barrelLocation.position, transform.forward, out hitLocation, Mathf.Infinity);
        if (raycast)
        {
            _desiredShootLocation = hitLocation.point;
        }
        else
        {
            _desiredShootLocation = barrelLocation.position + barrelLocation.forward * _weaponRange;
        }
    }

    private void HandleTurretRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(cameraTransform.eulerAngles.x , cameraTransform.eulerAngles.y , 0);//odj�cie i dodanie pozycji zwi�ksza odleg�o��i celownika od �rodka ekranu
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        shootAction.performed += _ => TryToShootNextBullet();
        //shootAction.performed += _ => ShootWeapon();
    }
    private void OnDisable()
    {
        shootAction.performed -= _ => TryToShootNextBullet();
        //shootAction.performed -= _ => ShootWeapon();
    }


    public void ShootWeapon()
    {
        GameObject bullet = Instantiate(bulletPrefab, barrelLocation.position, Quaternion.identity, bulletParent);
        BulletLogic bulletLogic = bullet.GetComponent<BulletLogic>();
        if (raycast)//strzela przed siebie dodac rotacje do minigun�w by obraca�y si� w strone kursora,dodac kursor pokazujacy gdzie dokladnie teraz poleci pocisk
        {
            bulletLogic.Target = hitLocation.point;
            bulletLogic.Hit = true;
        } 
        else
        {
            bulletLogic.Target = barrelLocation.position + barrelLocation.forward * _weaponRange;
            bulletLogic.Hit = false;
        }
    }
    float lastBulletShootTime;
    float secondsBetweenBullets = 1f;


    void TryToShootNextBullet()
    {
        Debug.Log(Time.realtimeSinceStartup);
        if (Time.realtimeSinceStartup >= lastBulletShootTime + secondsBetweenBullets)
            StartCoroutine(ShootBurstCoroutine());
    }

    IEnumerator ShootBurstCoroutine()
    {
        //Debug.Log("test2");
        lastBulletShootTime = Time.realtimeSinceStartup;
        for (int bulletNr = 0; bulletNr < 5; bulletNr++)
        {
            //Debug.Log("test3");
            ShootWeapon();
            yield return new WaitForSeconds(0.03f);
        }
    }
    /*
     * void Update(){
  if(IsShooting())
    TryToShootNextBullet();
}

float lastBulletShootTime;
float secondsBetweenBullets = 10f;


void TryToShootNextBullet(){
    if(Time.realTimeSinceStartup >= lastBulletShootTime + secondsBetweenBullets)
        StartCoroutine(ShootBurstCoroutine());
}

void ShootBurstCoroutine(){
    lastBulletShootTime = Time.realTimeSinceStartup;
    for(int bulletNr = 0; bulletNr<10; bulletNr++){
        ShootSingleBullet();
        yield return new WaitForSeconds(0.3f);
    }
}
     * */
}
