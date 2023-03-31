using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [Header("¼³Á¤")]
    private bool isPause = false;
    public float shootDistance = 10;
    public float speed = 0;
    public float attackRadius;

    public UnityEvent OnShooting;
    public UnityEvent<float, Transform> OnMovement;
    public UnityEvent<float> OnAttakDetect;

    private Rigidbody rigid;
    private Animator anim;

    private Transform target;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        target = GameManager.Instance.taget.transform;
    }
    private void FixedUpdate()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
    void Update()
    {
        Move();
        AttackDetect();
        //Shoot();
    }

    private void AttackDetect()
    {
        OnAttakDetect?.Invoke(attackRadius);
    }
    public void EventShooting()
    {
        OnShooting?.Invoke();
    }
    private void Move()
    {
        OnMovement?.Invoke(speed, target);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up,
            transform.forward * shootDistance);
    }
}
