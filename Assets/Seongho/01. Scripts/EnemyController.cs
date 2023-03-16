using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [Header("Ω∫≈»√¢")]
    public float speed = 0;
    public Transform target;
    public bool isMove = false;
    public UnityEvent OnShooting;
    public UnityEvent<float, Transform> OnMove;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isMove = true ? true : false;
        if (isMove)
            OnMove?.Invoke(speed, target);
    }
}
