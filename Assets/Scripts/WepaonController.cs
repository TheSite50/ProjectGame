using System.Collections;
using UnityEngine;

public abstract class WepaonController : MonoBehaviour, IShootable
{
    [SerializeField] so_weapon weaponData;
    float lastBulletShootTime;
    float secondsBetweenBullets = 1f;
    [SerializeField] private Transform bulletParent;
    private Transform cameraTransform;
    [SerializeField] private Behavior_hull Hull;
    Behavior_weapon weaponBehavior;

    int ammoInReserve;
    int totalAmmo;

    
    
    
    
    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        GunRotation();
    }

    #region Weapon Rotation

    void GunRotation()
    {
        Vector3 targetPoint = new Vector3(Hull.WhereLookLocation().x, 0, 0);
        this.transform.LookAt(targetPoint);
        //Quaternion targetRotation = Quaternion.Euler(cameraTransform.eulerAngles.x, 0, 0);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, weaponData.rotationSpeed * Time.deltaTime);
    }

    #endregion
    #region Weapon Shooting Logic
    /// <summary>
    /// public void TryToShootNextBullet()
    /// {
    ///     StartCoroutine(ShootCoroutine()); tak ma wygl¹daæ
    /// }
    /// </summary>
    public void TryToShootNextBullet()
    {
        if (weaponData.burstCount != 0)
        {
            if (Time.realtimeSinceStartup >= lastBulletShootTime + secondsBetweenBullets)
                StartCoroutine(ShootBurstCoroutine());
            return;
        }
        StartCoroutine(ShootFullAutoCoroutine());
    }
    IEnumerator ShootFullAutoCoroutine()
    {
        ShootWeapon(weaponData.barrelLocation.position, Hull.WhereLookLocation(), Hull.GetRaycast);
        yield return new WaitForSeconds(60 / weaponData.fireRate);
    }
    IEnumerator ShootBurstCoroutine()
    {

        lastBulletShootTime = Time.realtimeSinceStartup;
        for (int bulletNr = 0; bulletNr < weaponData.burstCount; bulletNr++)
        {
            ShootWeapon(weaponData.barrelLocation.position, Hull.WhereLookLocation(), Hull.GetRaycast);
            yield return new WaitForSeconds(60 / weaponData.fireRate);
        }
    }
    public void ShootWeapon(Vector3 whereFrom, Vector3 whereTo, bool didItHit)
    {
        GameObject bullet = Instantiate(weaponData.bulletPrefab, whereFrom, Quaternion.identity, bulletParent);
        BulletLogic bulletLogic = bullet.GetComponent<BulletLogic>();
        if (didItHit)//strzela przed siebie dodac rotacje do minigunów by obraca³y siê w strone kursora,dodac kursor pokazujacy gdzie dokladnie teraz poleci pocisk
        {
            bulletLogic.Target = whereTo;
            bulletLogic.Hit = true;
            return;
        }
        bulletLogic.Target = whereFrom + weaponData.barrelLocation.forward * weaponData.range;
        bulletLogic.Hit = false;
    }
    #endregion
}
