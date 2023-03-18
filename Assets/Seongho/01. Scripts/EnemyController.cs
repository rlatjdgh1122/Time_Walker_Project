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
    public bool isMove = false;
    public UnityEvent OnShooting;
    public UnityEvent<float, Transform> OnMove;
    public int radius = 3;
    private Rigidbody rigid;
    private Animator anim;
    public LayerMask layer;
    public bool isHit;

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
        /*bool isHit = Physics.Raycast(transform.position + Vector3.up,
            transform.forward, out hit, shootDistance);*/

        if (Physics.Raycast(transform.position + Vector3.up + Vector3.forward*2,
            transform.forward, out hit, shootDistance)) // 공격할 수 있는 상태
        {
            if (hit.collider.CompareTag("Player"))
                // OnShooting?.Invoke();
                isMove = false;
            else isMove = true;
        }
        else isMove = true;
    }

    private void Move()
    {
        if (isMove)
            OnMove?.Invoke(speed, target);
        else if(!isMove) OnMove?.Invoke(0, this.transform);
    }
    private void OnDrawGizmos()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(transform.position + Vector3.up + Vector3.forward,
            transform.forward, out hit, shootDistance, layer);
        if (isHit)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position + Vector3.up + Vector3.forward, transform.forward * hit.distance);
        }
        else

        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position + Vector3.up + Vector3.forward, transform.forward * shootDistance);
        }
    }
}
