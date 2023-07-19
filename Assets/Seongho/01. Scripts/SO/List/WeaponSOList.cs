using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class WeaponDataList
{
    public string WeaponName;
    public Weapon Weapon;
}
[CreateAssetMenu(menuName = "SO/WeaponList")]
public class WeaponSOList : ScriptableObject
{
    public List<WeaponDataList> Weapons = new();
}
