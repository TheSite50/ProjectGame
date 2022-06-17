using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIControll : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammunitionInRightWeapon;
    [SerializeField] private TextMeshProUGUI ammunitionInLeftWeapon;
    [SerializeField] private TextMeshProUGUI blueEssence;
    [SerializeField] private TextMeshProUGUI greenEssence;
    [SerializeField] private Image playerHp;
    [SerializeField] private GameObject player;
    private GameObject leftWeapon;
    private GameObject rightWeapon;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if (CreatePlayerInGame.GetWeaponLeft())
            leftWeapon = CreatePlayerInGame.GetWeaponLeft();
        else
        {
            leftWeapon = CreatePlayerInGame.GetArm().GetComponent<LocationWeapons>().GetWeaponPosition().weaponLeft.gameObject;
        }
        if (CreatePlayerInGame.GetWeaponRight() != null)
            rightWeapon = CreatePlayerInGame.GetWeaponRight();
        else
        {
            rightWeapon = CreatePlayerInGame.GetArm().GetComponent<LocationWeapons>().GetWeaponPosition().weaponRight.gameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHp.fillAmount = player.GetComponent<PlayerStats>().GetHp() / 1000f;
        if(playerHp.fillAmount <= 0.25)
        {
            playerHp.color = Color.red;
        }
        else
        if (playerHp.fillAmount < 0.4)
        {
            playerHp.color = Color.yellow;
        }
        else
        {
            playerHp.color = Color.green;
        }

        ammunitionInLeftWeapon.text = leftWeapon.GetComponent<WeaponParameter>().GetAmmunation().Item1 +"/"+ leftWeapon.GetComponent<WeaponParameter>().GetAmmunation().Item2;
        ammunitionInRightWeapon.text = rightWeapon.GetComponent<WeaponParameter>().GetAmmunation().Item1 + "/" + rightWeapon.GetComponent<WeaponParameter>().GetAmmunation().Item2;
        blueEssence.text = GameInformation.GetEssence().blueEssenceValue.ToString();
        greenEssence.text = GameInformation.GetEssence().greenEssenceValue.ToString();
    }
    public void UpdateEssenceValue(int blueEssenceValue, int greenEssenceValue)
    {
        this.blueEssence.text = blueEssenceValue.ToString();
        this.greenEssence.text = greenEssenceValue.ToString();
    }


}
