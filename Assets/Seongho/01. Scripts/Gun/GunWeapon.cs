using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunWeapon : MonoBehaviour
{
    public WeaponDataSO weaponDataSO;
    public Transform firePos;
    public GameObject bullet;

    private EnemyWeaponController enemyWeaponController = null;
    private void Awake()
    {
        enemyWeaponController = transform.root.GetComponent<EnemyWeaponController>(); //�ֻ��� �θ�

    }
    private void Start()
    {
        enemyWeaponController.OnShoot += Shoot;
    }
    public virtual void Shoot()
    {
        Vector3 randomPosition = -firePos.right
           + Random.insideUnitSphere * weaponDataSO.spreadAngle; //�̺κ� �����ʿ�
        float degreeY = Mathf.Atan2(randomPosition.z, firePos.position.x) * Mathf.Rad2Deg;
        float degreeZ = Mathf.Atan2(randomPosition.y, firePos.position.x) * Mathf.Rad2Deg;

        RegularBullet b = PoolManager.Instance.Pop(bullet.name) as RegularBullet;
        b.SetPositionAndRotation(firePos.position, Quaternion.Euler(0, degreeY, degreeZ));
      
    }
}
