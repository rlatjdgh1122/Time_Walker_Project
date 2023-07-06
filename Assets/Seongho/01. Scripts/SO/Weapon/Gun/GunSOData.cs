using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/GunData")]
public class GunSOData : WeaponSoData
{
    [Range(1, 5f)]
    public float attackDelay;
    [Range(0, 1f)]
    public float spreadAngle;

    public int bulletCount;
}
