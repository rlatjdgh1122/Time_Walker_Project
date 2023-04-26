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

        Vector3 randomPosition = Random.insideUnitSphere; //�̺κ� �����ʿ�

        Debug.Log(randomPosition);
        Debug.Log(firePos.position);
        Debug.Log(firePos.forward);

        Vector3 resultPos = randomPosition * weaponDataSO.spreadAngle + transform.forward;

        RegularBullet b = PoolManager.Instance.Pop(bullet.name) as RegularBullet;
        b.SetPositionAndRotation(firePos.position,Quaternion.LookRotation(resultPos));
      
    }
}
