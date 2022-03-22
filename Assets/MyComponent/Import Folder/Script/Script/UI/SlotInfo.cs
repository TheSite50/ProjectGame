using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SlotInfo",menuName ="SlotInfo/Slot")]
public class SlotInfo: ScriptableObject
{
    [SerializeField] static int idPrzedmiotu;
    [SerializeField] string nazwaPrzedmiotu;
    [SerializeField] public Sprite ikonaPrzedmiotu;
    [SerializeField] TypPrzedmiotu typPrzedmiotu;
    enum TypPrzedmiotu
    {
        Accessories,
        Weapon,
        Hands,
        Torso,
        Legs
    }

}
