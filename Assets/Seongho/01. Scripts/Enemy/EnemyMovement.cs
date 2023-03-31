using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private float attackRadius;
    private bool isMove { get; set; }
    private bool isRotate { get; set; }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    public void MoveAgent(float speed, Transform target)
    {
        if (isMove)
        {
            agent.speed = speed;

            agent.SetDestination(target.position);
        }
        else
        {
            agent.speed = 0;
            agent.SetDestination(this.transform.position);
        }
        MoveAnimation(agent.speed);
    }
    public void AttackDetect(float attackRadius)
    {
        this.attackRadius = attackRadius;
        AttackRaycast(attackRadius);
        Collider[] col = Physics.OverlapSphere(this.transform.position, attackRadius, 1 << LayerMask.NameToLayer("Player"));
        if (col.Length > 0) //플레이어가 감지됐다면 움직임을 멈추고 플레이어를 계속해서 쳐다봄
        {
            isMove = false; //움직임을 멈춤

            if (isRotate) //바라보는게 된다면
            {
                Transform targetPos = col[0].gameObject.transform;

                Vector3 rot = new Vector3(targetPos.position.x, transform.position.y, targetPos.position.z);
                transform.LookAt(rot); //플레이어를 계속해서 쳐다봄
            }
            else
                transform.LookAt(this.transform);
        }
        else
        {
            isMove = true; //움직임을 가동
            Debug.Log("플레이어가 감지되지 않음");
        }
    }
    private void AttackRaycast(float distance)
    {
        RaycastHit hit;
        bool IsHit = Physics.Raycast(transform.position + Vector3.up,
            transform.forward, out hit, distance, LayerMask.GetMask("Player"));
        if (IsHit)
        {
            Vector3 targetCenterPos =
            hit.collider.bounds.center;
            if (hit.point == targetCenterPos) //플레이어를 발견했다면 
            {
                //isRotate = false;
            }
        }
        //anim.SetBool("Shooting", !isMove && !isPause);
    }
    private void MoveAnimation(float speed)
    {
        anim.SetFloat("Move", speed);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, attackRadius);
    }
}
