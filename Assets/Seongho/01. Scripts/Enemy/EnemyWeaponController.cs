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

        Debug.Log(fireLocalPos);
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
                Debug.Log("�߻� ����");
                ammo--;
                //OnFeedbackShoot?.Invoke();
                Shooting();

            }
            else
            {
                Debug.Log("�Ѿ��� �ٶ�����");
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
        Debug.Log("����Ÿ��");
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
        Debug.Log("������ġ : " + randomPosition);
        Debug.Log("���ư� ���� : " + Quaternion.Euler(fireLocalPos - randomPosition).normalized);
        SpawnBullet(fireLocalPos, Quaternion.Euler(fireLocalPos - randomPosition).normalized);
        Debug.Log("�߻��");
    }
    private void SpawnBullet(Vector3 position, Quaternion rot)
    {

        RegularBullet b = PoolManager.Instance.Pop(weaponDataSO.bullet.name) as RegularBullet;

        /* Vector3 randomPosition = firePos.position + firePos.forward + (Vector3)Random.insideUnitCircle * 1;
         Vector3 direction = (randomPosition - firePos.position);

         regularBullet.Init();
         regularBullet.SetPositionAndRotation(firePos.position,
             Quaternion.LookRotation(direction));*/
        b.isEnemy = false;
    }

    public void StopShooting()
    {
        isShooting = false;
        //OnFeedbackStopShooting?.Invoke();
    }
}
