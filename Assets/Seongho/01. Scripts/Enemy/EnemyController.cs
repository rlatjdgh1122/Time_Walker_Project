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

    public EnemySoData EnemySoData;

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
        AttackDetect(EnemySoData.weaponData.attackRadius);
    }
    public void Shooting()
    {
        if (!cooldown.IsCooldown(cooltimeName))
        {
            cooldown.SetCooldown(cooltimeName, EnemySoData.weaponData.attackCoolTime);
            Debug.Log("��Ÿ�ӵ�");
            OnShooting?.Invoke();
            Debug.Log("�߻�");
        }
    }
    private void Move()
    {
        OnMovement?.Invoke(EnemySoData.weaponData.speed, target, isMove);
    }
    public void AttackDetect(float attackRadius)
    {
        AttackRaycast(attackRadius);
        inAttackDetect = cols.AttackDetect(attackRadius, transform.position);
        if (inAttackDetect)
        {
            isMove = false;
            if (isRotate) //���ƺ��� �Ѵٸ�
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
        if (isFace) //�����ɽ�Ʈ�� �÷��̾� �¾Ҵٸ�
        {
            Shooting();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up,
            transform.forward * EnemySoData.weaponData.shootDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, EnemySoData.weaponData.attackRadius);
    }
}
