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

    public UnityEvent OnShooting;
    public UnityEvent<float, Transform> OnMove;
    public UnityEvent<Vector3> OnAnimation;
    void Start()
    {

    }

    void Update()
    {
        OnMove?.Invoke(speed, target);
        OnAnimation?.Invoke(this.transform.position);
    }
}
