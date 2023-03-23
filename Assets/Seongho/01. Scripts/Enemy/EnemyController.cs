using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [Header("설정")]
    private bool isPause = false;
    public float shootDistance = 10;
    public float speed = 0;

    private bool isMove = false;

    public Transform target;
    public UnityEvent OnShooting;
    public UnityEvent<float, Transform> OnMove;

    private Rigidbody rigid;
    private Animator anim;
    private void Awake()
    {
        target = GameObject.Find("Player").transform;
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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

        if (Input.GetKeyDown(KeyCode.Q)) //퍼즈기능
            isPause = false;
        else if (Input.GetKeyUp(KeyCode.Q)) isPause = true;
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up,
            transform.forward, out hit, shootDistance)) // 공격할 수 있는 상태
        {
            if (hit.collider.CompareTag("Player"))
                isMove = false;

            else isMove = true;
        }
        else isMove = true;

        anim.SetBool("Shooting", !isMove && !isPause);
    }
    public void EventShooting()
    {
        OnShooting?.Invoke();
    }
    private void Move()
    {
        if (isMove)
            OnMove?.Invoke(speed, target);
        else if (!isMove) { OnMove?.Invoke(0, this.transform); };
    }
}
