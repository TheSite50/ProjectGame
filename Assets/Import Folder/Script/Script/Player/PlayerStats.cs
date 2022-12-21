using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IHp
{
    private float playerHp = 1000f;
    private int ammunationInMagazineLeftWeapon = 0;
    private int magazineNumberLeftWeapon = 0;
    private int ammunationInMagazineRightWeapon = 0;
    private int magazineNumberRightWeapon = 0;
    private WeaponParameter weaponAmmunationLeft = null;
    private WeaponParameter weaponAmmunationRight = null;
    private static GameObject player;
    [SerializeField] private Canvas gameOver;
    private void Awake()
    {
        player = this.gameObject;
    }

    private void Start()
    {
        
        if (CreatePlayerInGame.GetWeaponLeft())
        {
            weaponAmmunationLeft = CreatePlayerInGame.GetWeaponLeft().GetComponent<LocationWeapons>().GetWeaponPosition().weaponLeft.gameObject.GetComponent<WeaponParameter>();
        }
        else
        {
            weaponAmmunationLeft = CreatePlayerInGame.GetArm().GetComponent<LocationWeapons>().GetWeaponPosition().weaponLeft.gameObject.GetComponent<WeaponParameter>();
         }
        if (CreatePlayerInGame.GetWeaponRight() != null)
        {
            weaponAmmunationRight = CreatePlayerInGame.GetWeaponRight().GetComponent<LocationWeapons>().GetWeaponPosition().weaponRight.gameObject.GetComponent<WeaponParameter>();
        }
        else
        {
            weaponAmmunationRight = CreatePlayerInGame.GetArm().GetComponent<LocationWeapons>().GetWeaponPosition().weaponRight.gameObject.GetComponent<WeaponParameter>();
        }


    }
    public float GetHp()
    {
        return playerHp;
    }

    public void SetHp(float modifyHp)
    {
        this.playerHp = this.playerHp + modifyHp;
    }
    private void Update()
    {
        if (CreatePlayerInGame.GetWeaponLeft())
        {
            ammunationInMagazineLeftWeapon = weaponAmmunationLeft.GetAmmunation().Item1;
            magazineNumberLeftWeapon = weaponAmmunationLeft.GetAmmunation().Item2;
        }
        else
        {
            ammunationInMagazineLeftWeapon = weaponAmmunationLeft.GetAmmunation().Item1;
            magazineNumberLeftWeapon = weaponAmmunationLeft.GetAmmunation().Item2;
        }
        if (CreatePlayerInGame.GetWeaponRight() != null)
        {
            ammunationInMagazineRightWeapon = weaponAmmunationRight.GetAmmunation().Item1;
            magazineNumberRightWeapon = weaponAmmunationRight.GetAmmunation().Item2;
        }
        else
        {
            ammunationInMagazineRightWeapon = weaponAmmunationRight.GetAmmunation().Item1;
            magazineNumberRightWeapon = weaponAmmunationRight.GetAmmunation().Item2;
        }
        if (playerHp <= 0f)
        {
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void AddAmunation(int numberMagazine)
    {
        if (CreatePlayerInGame.GetWeaponLeft()!=null)
        {
            CreatePlayerInGame.GetWeaponLeft().GetComponent<LocationWeapons>().GetWeaponPosition().weaponLeft.gameObject.GetComponent<WeaponParameter>().AddAmmunation(0, numberMagazine);
            
        }
        else
        {
            CreatePlayerInGame.GetArm().GetComponent<LocationWeapons>().GetWeaponPosition().weaponLeft.gameObject.GetComponent<WeaponParameter>().AddAmmunation(0, numberMagazine);
            
        }
        if (CreatePlayerInGame.GetWeaponRight() != null)
        {
            CreatePlayerInGame.GetWeaponRight().GetComponent<LocationWeapons>().GetWeaponPosition().weaponRight.gameObject.GetComponent<WeaponParameter>().AddAmmunation(0, numberMagazine);
            
        }
        else
        {
            CreatePlayerInGame.GetArm().GetComponent<LocationWeapons>().GetWeaponPosition().weaponRight.gameObject.GetComponent<WeaponParameter>().AddAmmunation(0, numberMagazine);
        }

    }
    public static GameObject SendPlayer()
    {
        return player;
    }
}
