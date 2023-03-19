using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [Header("설정")]
    public float shootDistance = 10;
    public float speed = 0;
    public Transform target;
    public UnityEvent OnShooting;
    public UnityEvent<float, Transform> OnMove;

    private Rigidbody rigid;
    private bool isMove = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
    void Update()
    {
        Move();
        Shoot();
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up,
            transform.forward, out hit, shootDistance)) // 공격할 수 있는 상태
        {
            if (hit.collider.CompareTag("Player"))
            {
                OnShooting?.Invoke();
                isMove = false;
            }
            else isMove = true;
        }
        else isMove = true;
    }

    private void Move()
    {
        if (isMove)
            OnMove?.Invoke(speed, target);
        else if (!isMove) OnMove?.Invoke(0, this.transform);
    }
}
