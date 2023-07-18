using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyWeaponController : MonoBehaviour
{
    public Transform weaponPivot;

    public Action OnShoot = null; //공격 이벤트
    private EnemySOData enemySoData;
    /* public UnityEvent OnFeedbackShoot;
     public UnityEvent OnFeedbackNoAmmo;
     public UnityEvent OnFeedbackStopShooting;*/

    bool isShooting = false;
    bool isReloading = false;
    int ammo;
    private bool delayCoroutine;

   /* private void Awake()
    {
        enemySoData = GetComponent<EnemyController>().enemySoData;
    }
    private void Start()
    {
        Init();
        ammo = enemySoData.weaponData.ammoCapacity;
    }
    private GameObject weaponObj;
    public void Init()
    {
        weaponObj = Instantiate(enemySoData.weaponObject, weaponPivot);
    }
    public void WeaponThrow()
    {
        weaponObj.transform.SetParent(null);
        Rigidbody rigid = weaponObj.AddComponent<Rigidbody>();
        rigid?.AddForce(Vector3.forward * Random.Range(1,3),ForceMode.Impulse);
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
                ammo--;
                //OnFeedbackShoot?.Invoke();
                Shooting();

            }
            else
            {
                Debug.Log("총알이 다떨어짐");
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
        Debug.Log("장전타임");
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
        //animController.ShootAnim();
    }

    public void EventShooting()
    {
        for (int i = 0; i < enemySoData.weaponData.bulletCount; i++)
            OnShoot?.Invoke();
    }
    public void StopShooting()
    {
        isShooting = false;
        //OnFeedbackStopShooting?.Invoke();
    }*/
}
