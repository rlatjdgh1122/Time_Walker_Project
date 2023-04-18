using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemySoData")]
public class EnemySoData : ScriptableObject
{
    public GameObject weaponObject;
    public WeaponDataSO  weaponData => weaponObject.GetComponent<GunWeapon>().weaponDataSO;
}
