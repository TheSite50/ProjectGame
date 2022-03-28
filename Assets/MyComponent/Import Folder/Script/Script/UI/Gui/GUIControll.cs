using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIControll : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI amunationInWeapon;
    private GameObject leftWeapon;
    private GameObject rightWeapon;
    // Start is called before the first frame update
    void Start()
    {
        if (CreatePlayerInGame.GetWeaponLeft())
            leftWeapon = CreatePlayerInGame.GetWeaponLeft();
        else
        {
            leftWeapon = CreatePlayerInGame.GetArm();
        }
        if (CreatePlayerInGame.GetWeaponRight() != null)
            rightWeapon = CreatePlayerInGame.GetWeaponRight();
        else
        {
            rightWeapon = CreatePlayerInGame.GetArm();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        amunationInWeapon.text = leftWeapon.GetComponent<WeaponParameter>().GetAmmunation().Item1 +"/"+ leftWeapon.GetComponent<WeaponParameter>().GetAmmunation().Item2;
    }
}
