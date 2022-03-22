using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttack : MonoBehaviour, IWeapon
{
    private GameObject hand;
    [SerializeField] private GameObject weaponMuzzleLeft;
    [SerializeField] private GameObject weaponMuzzleRight;
    public void Attack(GameObject muzzle)
    {
        hand = CreatePlayerInGame.GetArm();
        if (hand.GetComponent<Animator>())
            hand.GetComponent<Animator>().SetTrigger("Attack");
    }

    public GameObject[] WeaponMuzzle()
    {
        return new GameObject[] { weaponMuzzleLeft, weaponMuzzleRight };
    }
}
