using UnityEngine;
[CreateAssetMenu(fileName ="WeaponScriptableObject", menuName ="ScriptableObjects/Weapons")]
public  class so_weapon : ScriptableObject
{
    public string name;
    [Header("Weapon Performance")]
    public int damage;
    public float fireRate;
    public int burstCount;
    [Header("Weapon Handling")]
    public int accuracy;
    public float recoil;
    public int range;
    public float rotationSpeed;
    public ShootingMode mode;
    [Header("Weapon Capacity")]
    public int magSize;
    public float reloadSpeed;
    [Header("Weapon Audio-Visual")]
    public AudioClip shootSound;
    public GameObject bulletPrefab;
    public Transform barrelLocation;
   
    public GameObject model;
}
