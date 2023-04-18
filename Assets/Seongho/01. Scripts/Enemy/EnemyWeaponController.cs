using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyWeaponController : MonoBehaviour
{
<<<<<<< Updated upstream
    private EnemyAnimationController animController;
=======
    public
        GameObject
        a;
>>>>>>> Stashed changes
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
    private void Start()
    {
<<<<<<< Updated upstream
        weapon = Instantiate(weaponDataSO.Weapon, weaponPivot);
        fireLocalPos = weaponDataSO.firePos.localPosition;

=======
        GameObject weapon = GameObject.Instantiate(weaponDataSO.Weapon, weaponPivot);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        animController.ShootAnim();

        Vector3 randomPosition = fireLocalPos + Vector3.forward + Random.insideUnitSphere * weaponDataSO.spreadAngle;
        Quaternion rot = Quaternion.LookRotation(randomPosition - fireLocalPos);
        Debug.Log("날아갈 방향 : " + rot);
        SpawnBullet(fireLocalPos, rot);
    }
    private void SpawnBullet(Vector3 position, Quaternion rot)
    {

        RegularBullet b = PoolManager.Instance.Pop(weaponDataSO.bullet.name) as RegularBullet;
=======
        Vector3 pos = transform.InverseTransformPoint(weaponDataSO.gunData.firePos.position);

        GameObject gameObject = Instantiate(a, pos, Quaternion.identity);

        Debug.Log(pos);

        Vector3 randomPosition = pos + pos * 5 + Random.insideUnitSphere * weaponDataSO.spreadAngle;

        Vector3 direction = (randomPosition - pos).normalized;
        float deree1 = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        float deree2 = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        RegularBullet b = PoolManager.Instance.Pop(weaponDataSO.bullet.name) as RegularBullet;
        b.Init();
        b.SetPositionAndRotation(pos, Quaternion.Euler(0, deree1, deree2));

>>>>>>> Stashed changes
        b.isEnemy = false;
    }
    /* private void SpawnBullet(Vector3 position, Quaternion rot)
     {

     }*/

    public void StopShooting()
    {
        isShooting = false;
        //OnFeedbackStopShooting?.Invoke();
    }
}
