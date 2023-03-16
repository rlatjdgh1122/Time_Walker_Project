using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    public void MoveAgent(float speed, Transform target)
    {
        agent.speed = speed;
        agent.SetDestination(target.position);
        MoveAnimation(agent.speed);
    }
    public void MoveAnimation(float speed)
    {
        anim.SetFloat("Move", speed);
    }
}
