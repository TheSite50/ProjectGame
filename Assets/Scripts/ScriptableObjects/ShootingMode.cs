using UnityEngine;
public abstract class ShootingMode : ScriptableObject
{
    public abstract void Shoot(weaponSystem weapon);
}
