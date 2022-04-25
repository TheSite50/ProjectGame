using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpperPartScript : MonoBehaviour
{
    private PlayerInput playerInput;
    //[SerializeField] private Animator animator;

    [SerializeField] private float rotationSpeed = 25f;
    private GameObject bulletPrefab;
    private Transform barrelLocation;
    //[SerializeField] private Transform bulletParent;
    [SerializeField] float _weaponRange = 100f;

    private Transform cameraTransform;
    private InputAction shootAction;

    public Vector3 whereLookLocation;   //gdzie celuje
    public Vector3 desiredShootLocation;//gdzie lec¹ naboje
   // public Vector3 whereShootLocation;
    bool raycast;

    void Start()
    {
        playerInput = CreatePlayerInGame.GetPlayer().GetComponent<PlayerInput>();
        barrelLocation = CreatePlayerInGame.GetArm().GetComponent<SetOfMiniguns>().WeaponMuzzle().weaponMuzzleLeft.transform;
        //error repair
        bulletPrefab = CreatePlayerInGame.GetArm().GetComponent<IWeapon>().GetBullet();
        cameraTransform = Camera.main.transform;
        shootAction = playerInput.actions["Fire"];
        shootAction.performed += _ => TryToShootNextBullet();
        
    }

    void Update()
    {
        HandleTurretRotation();

        LookDirection();
        Debug.Log(whereLookLocation);
        
        
    }
    //zmieniæ strzelanie na raycasty zamiast projectile
    #region Aiming
    private void LookDirection()//yellow raycast z kamery który nakierowuje mecha gzie ma patrzeæ
    {
        raycast = Physics.Raycast(cameraTransform.position, transform.forward, out RaycastHit cameraLookAtPoint, _weaponRange);
        Debug.DrawRay(cameraTransform.position, transform.forward * _weaponRange, Color.yellow);
        if (raycast)
        {
            whereLookLocation=cameraLookAtPoint.point;
            return;
        }
        whereLookLocation=transform.forward * _weaponRange;
    }
   
    #endregion


    private void HandleTurretRotation()
    {
        //Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        Quaternion targetRotation = Quaternion.Euler(cameraTransform.eulerAngles.x , cameraTransform.eulerAngles.y , 0);//odjêcie i dodanie pozycji zwiêksza odleg³oœæi celownika od œrodka ekranu
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    //private void OnEnable()
    //{
    //    shootAction.performed += _ => TryToShootNextBullet();
    //    //shootAction.performed += _ => ShootWeapon();
    //}
    //private void OnDisable()
    //{
    //    shootAction.performed -= _ => TryToShootNextBullet();
    //    //shootAction.performed -= _ => ShootWeapon();
    //}

/*    public void ShootWeapon()
    {
        GameObject bullet = Instantiate(bulletPrefab, barrelLocation.position, Quaternion.identity, bulletParent);
        BulletLogic bulletLogic = bullet.GetComponent<BulletLogic>();
        bulletLogic.Target = desiredShootLocation;
        if (raycast) 
        {
            bulletLogic.Hit = true;
            return;
        }
        bulletLogic.Hit = false;
    }*/
    public void ShootRaycast()
    {
        bool shootRaycast = Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit shootAtLocation, _weaponRange);
        if (shootRaycast)
        {
            desiredShootLocation = barrelLocation.position + barrelLocation.forward * _weaponRange;
            //desiredShootLocation = shootAtLocation.point;
            return;
        }
        desiredShootLocation = cameraTransform.position + barrelLocation.forward * _weaponRange;
    }

    public void ShootWeapon()
    {
        GameObject bullet = Instantiate(bulletPrefab, barrelLocation.position , barrelLocation.rotation );
        BulletLogic bulletLogic = bullet.GetComponent<BulletLogic>();
        if (raycast)//strzela przed siebie dodac rotacje do minigunów by obraca³y siê w strone kursora,dodac kursor pokazujacy gdzie dokladnie teraz poleci pocisk
        {
            bulletLogic.Target = whereLookLocation;
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
     private void WhereisGoingToShoot()//green obrót kabiny która 
    {
        whereShootLocation = new Vector3(transform.forward.x, whereLookLocation.y, transform.forward.z).normalized;
        Debug.Log(whereShootLocation);
        
        raycast = Physics.Raycast(transform.position, whereShootLocation, out RaycastHit hitLocation, _weaponRange);
        Debug.DrawRay(transform.position, whereShootLocation * _weaponRange, Color.green);
        if (raycast)
        {
            barrelLocation.LookAt(hitLocation.point);
            Debug.Log(hitLocation.point);
            return;
        }
        Debug.Log(hitLocation.point);
        barrelLocation.LookAt(transform.forward * _weaponRange);
    }
    private void WhereIsShooting()//blue
    {
        bool barrelRaycast = Physics.Raycast(barrelLocation.position, barrelLocation.forward, out RaycastHit HitPlace, _weaponRange);
        Debug.DrawRay(barrelLocation.position, barrelLocation.forward * _weaponRange, Color.blue);
        if (barrelRaycast)
        {
            desiredShootLocation = HitPlace.point;
            return;
        }
        desiredShootLocation = barrelLocation.position + barrelLocation.forward * _weaponRange;
    }
     * */
}
