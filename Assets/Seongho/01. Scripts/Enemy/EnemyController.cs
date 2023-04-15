using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEditor.Build;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    //public EnemySoData enemySoData;

    public WeaponDataSO weaponDataSO;

    [HideInInspector]
    public bool isPause = false;

    public UnityEvent OnShooting;
    public UnityEvent<float, Transform, bool> OnMovement;

    private Rigidbody rigid;


    private Transform target;
    private CooldownManager cooldown = new CooldownManager();
    private bool isMove = true;
    private bool isRotate = false;
    private bool inAttackDetect;
    private bool isHit = false;
    private Collider[] cols = null;

    private string cooltimeName = "EnemyAttackCoolTime";

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        target = GameManager.Instance.target.transform;
    }
    private void FixedUpdate()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
    void Update()
    {
        Move();
        AttackDetect(weaponDataSO.attackRadius);
        Pause();
        Debug.Log(isRotate);
    }

    private void Pause()
    {
        if (isPause)
            Time.timeScale = 0;
        else Time.timeScale = 1;
    }
    public void Shooting()
    {
        if (!cooldown.IsCooldown(cooltimeName))
        {
            cooldown.SetCooldown(cooltimeName, weaponDataSO.attackCoolTime);
            Debug.Log("쿨타임돎");
            OnShooting?.Invoke();
        }
    }
    private void Move()
    {
        OnMovement?.Invoke(weaponDataSO.speed, target, isMove);
    }
    public void AttackDetect(float attackRadius)
    {
        AttackRaycast(attackRadius);
        inAttackDetect = cols.AttackDetect(attackRadius, transform.position);
        if (inAttackDetect)
        {
            isMove = false;
            if (isRotate) //돌아봐야 한다면
            {
                Quaternion rotTarget = Quaternion.LookRotation(target.position - this.transform.position);
                this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, 150 * Time.deltaTime);
            }
            else if (!isRotate)
            {
                transform.LookAt(this.transform);
            }
        }
        else
            isMove = true;
    }
    private void AttackRaycast(float distance)
    {
        bool isFace = isHit.FaceDetect(distance, out isRotate, this.transform);
        if (isFace) //레이케스트가 플레이어 맞았다면
        {
            Shooting();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up,
            transform.forward * weaponDataSO.shootDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, weaponDataSO.attackRadius);
    }
}
