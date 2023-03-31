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
    [Header("설정")]
    private bool isPause = false;
    public float shootDistance = 10;
    public float speed = 0;

    private bool isMove = false;

    public UnityEvent OnShooting;
    public UnityEvent<float, Transform> OnMove;

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
        Shoot();

        if (Input.GetKeyDown(KeyCode.Q)) //퍼즈기능
            isPause = false;
        else if (Input.GetKeyUp(KeyCode.Q)) isPause = true;
    }
    private void Shoot()
    {
        RaycastHit hit;
        bool IsHit = Physics.Raycast(transform.position + Vector3.up,
            transform.forward, out hit, shootDistance,LayerMask.NameToLayer("Player")); 
        if (IsHit)
        {
            if (hit.collider.gameObject.transform.GetChild(0).CompareTag("HitCore"))
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up,
            transform.forward * shootDistance);
    }
}
