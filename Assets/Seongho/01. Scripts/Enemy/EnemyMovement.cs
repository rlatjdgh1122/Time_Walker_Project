using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;

public class EnemyMovement : EnemyAnimationController
{
    private EnemyController _enemyController;
    private NavMeshAgent _agent;
    private Vector3 lastPosition; // 마지막 위치 저장
    protected override void Awake()
    {
        base.Awake();
        _agent = GetComponent<NavMeshAgent>();
        _enemyController = GetComponent<EnemyController>();
    }
    private void Start()
    {
        lastPosition = transform.position;
    }
   
}