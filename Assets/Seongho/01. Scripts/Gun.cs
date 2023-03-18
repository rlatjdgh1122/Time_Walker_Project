using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    protected WeaponGun weapon;
    public Transform gunPivot;
    protected virtual void Awake()
    {
        weapon = GetComponentInChildren<WeaponGun>();
        this.transform.position = gunPivot.position;
    }
    public virtual void Shoot()
    {
        weapon?.TryShooting();
    }
    public virtual void StopShooting()
    {
        weapon?.StopShooting();
    }

}
