using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    public GameObject Weapon;
    public GameObject bullet;
   
    public Transform firePos => Weapon.transform.Find("FirePos").transform;
    public bool meleeAttackWeapon = false;


    public float attackCoolTime;
    public float shootDistance;
    public float speed;
    public float attackRadius => shootDistance;

    [Range(5, 100f)]
    public int ammoCapacity;
    [Range(1, 5f)]
    public float weaponDelay;
    [Range(0, 100f)]
    public float spreadAngle;
    [Range(1, 3f)]
    public float reloadTime;
    
    public int bulletCount;

    public AudioClip reloadClip;
}
