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
    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }
    public void MoveAgent(float speed, Transform target, bool isMove)
    {
        agent.speed = speed;
        if (isMove)
        {
            agent.isStopped = false;
        }
        else
        {
            agent.isStopped = true;
        }
        agent.SetDestination(target.position);
        MoveAnim(transform.hasChanged); //tranform에 변경여부
    }
}