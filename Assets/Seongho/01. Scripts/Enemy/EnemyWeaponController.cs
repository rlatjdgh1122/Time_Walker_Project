using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyWeaponController : MonoBehaviour
{
    private EnemyAnimationController animController;
    private EnemySoData enemySoData;
    public Transform weaponPivot;

    public Action OnShoot;
    /* public UnityEvent OnFeedbackShoot;
     public UnityEvent OnFeedbackNoAmmo;
     public UnityEvent OnFeedbackStopShooting;*/

    bool isShooting = false;
    bool isReloading = false;
    int ammo;
    private bool delayCoroutine;

    private void Awake()
    {
        animController = GetComponent<EnemyAnimationController>();
        enemySoData = GetComponent<EnemyController>().EnemySoData;
    }
    private void Start()
    {

        Init();
        ammo = enemySoData.weaponData.ammoCapacity;
    }
    public void Init()
    {
        Instantiate(enemySoData.weaponObject, weaponPivot);
    }
    public void shoot()
    {
        if (isReloading) return;
        else
            TryShooting();
    }
    public void TryShooting()
    {

        isShooting = true;
        if (isShooting && delayCoroutine == false)
        {
            if (ammo > 0)
            {
                Debug.Log("πﬂªÁ ∞°¥…");
                ammo--;
                //OnFeedbackShoot?.Invoke();
                Shooting();

            }
            else
            {
                Debug.Log("√—æÀ¿Ã ¥Ÿ∂≥æÓ¡¸");
                isShooting = false;
                Reloading();
                //OnFeedbackNoAmmo?.Invoke();
                return;
            }
        }
        FinishOneShooting();
    }
    private void FinishOneShooting()
    {
        StartCoroutine(DelayNextShootCoroutine());
    }
    private IEnumerator DelayNextShootCoroutine()
    {
        delayCoroutine = true;
        yield return new WaitForSeconds(enemySoData.weaponData.weaponDelay);
        delayCoroutine = false;
    }
    private void Reloading()
    {
        StartCoroutine(reloadCoroutine());
    }

    private IEnumerator reloadCoroutine()
    {
        Debug.Log("¿Â¿¸≈∏¿”");
        isReloading = true;
        yield return new WaitForSeconds(enemySoData.weaponData.reloadTime);
        isReloading = false;
        Reload();
    }
    private void Reload()
    {
        ammo = enemySoData.weaponData.ammoCapacity;
    }
    private void Shooting()
    {
        animController.ShootAnim();
        Debug.Log(OnShoot);
        OnShoot?.Invoke();
    }
    public void StopShooting()
    {
        isShooting = false;
        //OnFeedbackStopShooting?.Invoke();
    }
}
