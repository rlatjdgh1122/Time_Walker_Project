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
    private WeaponDataSO weaponDataSO;
    public Transform weaponPivot;

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
        weaponDataSO = GetComponent<EnemyController>().weaponDataSO;
    }
    private GameObject weapon;
    private Vector3 fireLocalPos;
    private void Start()
    {
        weapon = Instantiate(weaponDataSO.Weapon, weaponPivot);
        fireLocalPos = weaponDataSO.firePos.localPosition;

        ammo = weaponDataSO.ammoCapacity;
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
                Debug.Log("발사 가능");
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
        yield return new WaitForSeconds(weaponDataSO.weaponDelay);
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
        yield return new WaitForSeconds(weaponDataSO.reloadTime);
        isReloading = false;
        Reload();
    }
    private void Reload()
    {
        ammo = weaponDataSO.ammoCapacity;
    }


    private void Shooting()
    {
        animController.ShootAnim();

        Vector3 randomPosition = fireLocalPos + Vector3.forward + Random.insideUnitSphere * weaponDataSO.spreadAngle;
        Quaternion rot = Quaternion.LookRotation(randomPosition - fireLocalPos);
        Debug.Log("날아갈 방향 : " + rot);
        SpawnBullet(fireLocalPos, rot);
    }
    private void SpawnBullet(Vector3 position, Quaternion rot)
    {

        RegularBullet b = PoolManager.Instance.Pop(weaponDataSO.bullet.name) as RegularBullet;
        b.isEnemy = false;
    }

    public void StopShooting()
    {
        isShooting = false;
        //OnFeedbackStopShooting?.Invoke();
    }
}
