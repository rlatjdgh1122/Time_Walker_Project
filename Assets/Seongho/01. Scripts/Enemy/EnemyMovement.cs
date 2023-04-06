using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    public void MoveAgent(float speed, Transform target, bool isMove)
    {
        if (isMove)
        {
            agent.speed = speed;

            agent.SetDestination(target.position);
        }
        else
        {
            agent.speed = 0;
            agent.SetDestination(Vector3.zero);
        }
        MoveAnimation(agent.speed);
    }

    private void MoveAnimation(float speed)
    {
        anim.SetFloat("Move", speed);
    }
}