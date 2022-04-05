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
    [SerializeField] float _weaponRange = 100f;
    [SerializeField] private PlayerInput playerInput;
    private Transform cameraTransform;
    private InputAction shootAction;
    [SerializeField] private Animator animator;
    public Vector3 _desiredShootLocation;//gdzie jest celownik
    RaycastHit hitLocation;
    bool raycast;
    //LayerMask layers = LayerMask.GetMask();
    void Awake()
    {
        cameraTransform = Camera.main.transform;
        shootAction = playerInput.actions["Fire"];
    }

    void Update()
    {
        
       
        
        //Debug.Log(transform.rotation.eulerAngles);
        HandleTurretRotation();
        //_turretRotation = cameraTransform.localPosition;
        //Debug.Log(_desiredShootLocation);
        raycast = Physics.Raycast(barrelLocation.position, transform.forward, out hitLocation, Mathf.Infinity);
        if (raycast)//strzela przed siebie dodac rotacje do minigunów by obraca³y siê w strone kursora,dodac kursor pokazujacy gdzie dokladnie teraz poleci pocisk
        {
            _desiredShootLocation = hitLocation.point;
        }
        else
        {
            _desiredShootLocation = barrelLocation.position + barrelLocation.forward * _weaponRange;
        }

        //_turretRotation = Quaternion.Euler(transform.rotation.eulerAngles - cameraTransform.position) ;
        //Debug.Log(cameraTransform.localPosition);
    }

    private void HandleTurretRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(cameraTransform.eulerAngles.x , cameraTransform.eulerAngles.y , 0);//odjêcie i dodanie pozycji zwiêksza odleg³oœæi celownika od œrodka ekranu
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
        if (raycast)//strzela przed siebie dodac rotacje do minigunów by obraca³y siê w strone kursora,dodac kursor pokazujacy gdzie dokladnie teraz poleci pocisk
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
        Debug.Log("test2");
        lastBulletShootTime = Time.realtimeSinceStartup;
        for (int bulletNr = 0; bulletNr < 5; bulletNr++)
        {
            Debug.Log("test3");
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
