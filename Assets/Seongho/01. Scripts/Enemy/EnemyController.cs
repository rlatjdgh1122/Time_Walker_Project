using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemySoData enemySoData;

    public bool isPause = false;


    public UnityEvent OnShooting;
    public UnityEvent<float, Transform, bool> OnMovement;

    private Rigidbody rigid;


    private Transform target;
    private CooldownManager cooldown;
    private bool isMove = true;
    private bool isRotate = false;
    private bool inAttackDetect;
    private bool isHit;
    private Collider[] cols;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        target = GameManager.Instance.target.transform;

        cooldown = new CooldownManager();
        cooldown.SetCooldown("EnemyAttackCoolTime", enemySoData.attackCoolTime);
    }
    private void FixedUpdate()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
    void Update()
    {
        Move();
        AttackDetect(enemySoData.attackRadius);

        Pause();
    }

    private void Pause()
    {
        if (isPause)
            Time.timeScale = 0;
        else Time.timeScale = 1;
    }
    public void Shooting()
    {
        if (cooldown.IsCooldown("EnemyAttackCoolTime"))
            OnShooting?.Invoke();
    }

    private void Move()
    {
        OnMovement?.Invoke(enemySoData.speed, target, isMove);
    }
    public void AttackDetect(float attackRadius)
    {
        AttackRaycast(attackRadius);

        inAttackDetect = cols.AttackDetect(attackRadius, transform.position);
        if (inAttackDetect && isRotate) //범위 안에 들어왔다면
        {
            isMove = false; //움직임을 멈춤

            Vector3 rot = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(rot); //플레이어를 계속해서 쳐다봄
        }
        else
        {
            transform.LookAt(this.transform);
            isMove = true; //움직임을 멈춤
            Shooting();
        }
    }
    private void AttackRaycast(float distance)
    {
        RaycastHit hit;
        bool isFace = isHit.FaceDetect(distance, out hit, transform);
        if (isFace)
        {
            Vector3 targetCenterPos =
            hit.collider.bounds.center;
            if (hit.point == targetCenterPos) //플레이어를 발견했다면 
            {
                isRotate = false;
            }
            else isRotate = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up,
            transform.forward * enemySoData.shootDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemySoData.attackRadius);
    }
}
