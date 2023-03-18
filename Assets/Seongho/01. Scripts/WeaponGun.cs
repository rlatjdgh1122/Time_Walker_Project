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
    bool delayCoroutine = false;
    int ammo;
    private void Awake()
    {
        ammo = gunData.ammoCapacity;
    }
    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        if (isShooting && delayCoroutine == false)
        {
            if (ammo > 0)
            {
                OnFeedbackShoot?.Invoke();
                ShootBullet();
            }
            else
            {
                isShooting = false;
                OnFeedbackNoAmmo?.Invoke();
                return;
            }
            FinishOneShooting();
        }
    }

    private void FinishOneShooting()
    {
        StartCoroutine(DelayNextShootingCorotine());
        if (gunData.autoFire == false)
            isShooting = false;
    }
    private IEnumerator DelayNextShootingCorotine()
    {
        delayCoroutine = true;
        yield return new WaitForSeconds(gunData.weaponDelay);
        delayCoroutine = false;
    }
    private void ShootBullet()
    {
        GameObject GO = Instantiate(gunData.bullet, firePos.position, Quaternion.identity);
    }

    public virtual void Shooting()
    {
        Debug.Log("½¸");
        GameObject gameObject = Instantiate(gunData.bullet, firePos.position, Quaternion.identity);
    }
    public void TryShooting()
    {
        isShooting = true;
    }
    public void StopShooting()
    {
        isShooting = false;
        OnFeedbackStopShooting?.Invoke();
    }
}
