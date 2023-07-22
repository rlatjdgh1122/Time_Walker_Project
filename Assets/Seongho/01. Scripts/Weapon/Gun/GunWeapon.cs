using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GunWeapon : Weapon
{
    public GunSOData gunData;
    public Transform firePos;
    public GameObject bullet;

    //private GameObject pt => transform.Find("Paticle").gameObject;

    public UnityEvent OnShoot;
    public UnityEvent OnShootNoAmmo;
    public UnityEvent OnStopShooting; //feedback�߰�

   /* [SerializeField]
    private bool _isShooting = false;

    public bool delayCoroutine = false;

    #region AMMO ���� �ڵ��
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
    public int EmptyBullet => gunData.ammoCapacity - ammo; //���� ������ ź�� ��
    #endregion*/
    protected override void Awake()
    {
        base.Awake();
        Hiden_Particle();
    }
    private void Hiden_Particle()
    {
        //spt.SetActive(false);
    }
    private void SpawnBullet()
    {
        Vector3 randomPosition = Random.insideUnitSphere; //�̺κ� �����ʿ�
        Vector3 resultPos = randomPosition * gunData.spreadAngle + transform.forward;

        RegularBullet b = PoolManager.Instance.Pop(bullet.name) as RegularBullet;
        b.SetPositionAndRotation(firePos.position, Quaternion.LookRotation(resultPos));
    }
    private void ShootBullet()
    {
        SpawnBullet();
        //SoundManager.Instance.PlayerSoundName(gunData.SoundName);
        //pt.SetActive(true);
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
