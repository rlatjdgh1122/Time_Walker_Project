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
    private NavMeshAgent agent;
    private Vector3 lastPosition; // 마지막 위치 저장
    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        lastPosition = transform.position;
    }
    public void MoveAgent(float speed, Transform target, bool isMove)
    {
        agent.speed = speed;
        agent.SetDestination(target.position);
        if (isMove)
        {
            agent.isStopped = false;
        }
        else if (!isMove)
        {
            agent.isStopped = true;
        }

        if (transform.position != lastPosition)
        {
            MoveAnim(true); //tranform에 변경여부
            lastPosition = transform.position;
        }
        else
            MoveAnim(false); //tranform에 변경여부
    }
}