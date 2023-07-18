using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class WeaponClass
{
    public GunWeapon WeaponObject;
    [Range(0f, 1f)]
    public float Weight;
}
[CreateAssetMenu(menuName = "SO/WeaponList")]
public class WeaponList : ScriptableObject
{
    public List<WeaponClass> Weapons = new();
}
