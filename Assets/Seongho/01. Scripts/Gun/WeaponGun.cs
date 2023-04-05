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
                Shooting();
            }
            else
            {
                isShooting = false;
                OnFeedbackNoAmmo?.Invoke();
                return;
            }
            //FinishOneShooting();
        }
    }

/*    private void FinishOneShooting()
    {
        StartCoroutine(DelayNextShootingCorotine());
    }*/
/*    private IEnumerator DelayNextShootingCorotine()
    {
        delayCoroutine = true;
        yield return new WaitForSeconds(gunData.weaponDelay);
        delayCoroutine = false;
    }*/
    public virtual void Shooting()
    {
        ammo--;

        GameObject gameObject = Instantiate(gunData.bullet, firePos.position, transform.rotation);
        gameObject.transform.SetParent(firePos);
        Destroy(gameObject, gunData.liveBulletTime);
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
