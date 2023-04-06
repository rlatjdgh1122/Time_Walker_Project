using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class WeaponGun : MonoBehaviour
{
    public GunSOData gunData;
    public Transform firePos;

    public UnityEvent OnFeedbackShoot;
    public UnityEvent OnFeedbackNoAmmo;
    public UnityEvent OnFeedbackStopShooting;
    bool isShooting;
    int ammo;

    private GameObject target;
    private void Awake()
    {
        ammo = gunData.ammoCapacity;
        target = GameManager.Instance.target;
    }
    public virtual void Shooting()
    {
        GameObject gameObject = Instantiate(gunData.bullet, firePos.position,
            Quaternion.Euler(new Vector3(0, -90, 0)));
        gameObject.transform.SetParent(firePos);
        Destroy(gameObject, gunData.liveBulletTime);

    }
    public void TryShooting()
    {
        isShooting = true;
        if (isShooting)
        {
            if (ammo > 0)
            {
                ammo--;
                OnFeedbackShoot?.Invoke();
                Shooting();
            }
            else
            {
                isShooting = false;
                OnFeedbackNoAmmo?.Invoke();
                return;
            }
        }
    }
    public void StopShooting()
    {
        isShooting = false;
        OnFeedbackStopShooting?.Invoke();
    }
}
