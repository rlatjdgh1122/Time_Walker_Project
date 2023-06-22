using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GunWeapon : Weapon
{
    public WeaponSOData gunData;
    public Transform firePos;
    public GameObject bullet;

    private GameObject pt => transform.Find("Paticle").gameObject;

    public UnityEvent OnShoot;
    public UnityEvent OnShootNoAmmo;
    public UnityEvent OnStopShooting; //feedback추가

   /* [SerializeField]
    private bool _isShooting = false;

    public bool delayCoroutine = false;

    #region AMMO 관련 코드들
    [SerializeField]
    protected int ammo;
    public int Ammo
    {
        get { return ammo; }
        set
        {
            ammo = Math.Clamp(value, 0, gunData.ammoCapacity);
        }
    }
    public bool AmmoFull => Ammo == gunData.ammoCapacity;
    public int EmptyBullet => gunData.ammoCapacity - ammo; //현재 부족한 탄약 수
    #endregion*/
    protected override void Awake()
    {
        base.Awake();
        Hiden_Particle();
        if (gunData.animatiorController != null)
        {
            animatorController.runtimeAnimatorController = gunData.animatiorController;
        }
    }
    private void Hiden_Particle()
    {
        pt.SetActive(false);
    }
    private void SpawnBullet()
    {
        Vector3 randomPosition = Random.insideUnitSphere; //이부분 수정필요
        Vector3 resultPos = randomPosition * gunData.spreadAngle + transform.forward;

        RegularBullet b = PoolManager.Instance.Pop(bullet.name) as RegularBullet;
        b.SetPositionAndRotation(firePos.position, Quaternion.LookRotation(resultPos));
    }
    private void ShootBullet()
    {
        SpawnBullet();
        //SoundManager.Instance.PlayerSoundName(gunData.SoundName);
        pt.SetActive(true);
        Invoke("Hiden_Particle", .1f);
    }
    public override void Shooting()
    {
        ShootBullet();

    }
    public override void StopShooting()
    {
    }
}
