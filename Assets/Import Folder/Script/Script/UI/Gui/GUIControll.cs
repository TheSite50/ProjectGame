using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIControll : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI amunationInWeapon;
    [SerializeField] private TextMeshProUGUI blueEssence;
    [SerializeField] private TextMeshProUGUI greenEssence;
    [SerializeField] private Slider playerHp;
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
        playerHp.value = player.GetComponent<PlayerStats>().GetHp()/1000f;
        //amunationInWeapon.text = leftWeapon.GetComponent<WeaponParameter>().GetAmmunation().Item1 +"/"+ leftWeapon.GetComponent<WeaponParameter>().GetAmmunation().Item2;
        blueEssence.text = GameInformation.GetEssence().blueEssenceValue.ToString();
        greenEssence.text = GameInformation.GetEssence().greenEssenceValue.ToString();
    }
    public void UpdateEssenceValue(int blueEssenceValue, int greenEssenceValue)
    {
        this.blueEssence.text = blueEssenceValue.ToString();
        this.greenEssence.text = greenEssenceValue.ToString();
    }


}
