using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
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
    public EnemySoData EnemySoData;

    public UnityEvent OnShooting;
    public UnityEvent<float, Transform, bool> OnMovement;

    private Rigidbody rigid;


    private Transform target;
    private CooldownManager cooldown = new CooldownManager();

    private bool isMove = true;

    private bool inAttackDetect;
    private Collider[] cols = null;

    private string cooltimeName = "EnemyAttackCoolTime";

    private Vector3 direction = Vector3.zero;

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
        direction = (target.position - transform.position).normalized;
        Move();
        AttackRaycast(EnemySoData.weaponData.shootDistance);
        Debug.Log("움직이는가 : " + isMove);
    }

    private void Move()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance < EnemySoData.weaponData.attackRadius
         && HideInWalk())
        {
            isMove = false;
        }
        else isMove = true;

        OnMovement?.Invoke(EnemySoData.weaponData.speed, target, isMove);
    }
    private void AttackRaycast(float distance)
    {
        RaycastHit hit;
        bool isAttackHit = Physics.Raycast(transform.position + Vector3.up, transform.forward, out hit, distance);

        if (isAttackHit)
        {
            if (hit.collider.CompareTag("Player"))
            {
                Shooting();
            }
        }
    }
    private bool HideInWalk()
    {
        RaycastHit hit;
        bool isHideInWalk = Physics.Raycast(transform.position + Vector3.up, direction, out hit, 1000);

        if (isHideInWalk)
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("플레이어 맞음");
                return false;
            }
        }
        return true;
    }
    public void Shooting()
    {
        if (!cooldown.IsCooldown(cooltimeName))
        {
            cooldown.SetCooldown(cooltimeName, EnemySoData.weaponData.attackCoolTime);
            Debug.Log("쿨타임돎");
            OnShooting?.Invoke();
            Debug.Log("발사");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up,
            transform.forward * EnemySoData.weaponData.shootDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position + Vector3.up, direction * 1000);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, EnemySoData.weaponData.attackRadius);
    }
}
