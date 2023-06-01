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
    public Vector3 Target;
    public bool isSetActive = true;
    private bool isMove = true;
    private bool isRotate = true;

    private EnemyController _enemyController;
    private NavMeshAgent _agent;
    protected override void Awake()
    {
        base.Awake();
        _agent = GetComponent<NavMeshAgent>();
        _enemyController = GetComponent<EnemyController>();
    }

    private void Start()
    {
        _agent.isStopped = true;
        Target = GameManager.Instance.PlayerTrm.position;

        SetSpeed(_enemyController.EnemySoData.weaponData.speed);
    }
    public void SetTarget(Vector3 target)
    {
        Target = target;
    }
    public void StopMove()
    {
        isMove = false;
        _agent.SetDestination(transform.position);
    }
    public void StartMove()
    {
        isMove = true;
    }
    public void SetSpeed(float speed)
    {
        _agent.speed = speed;
    }
    public bool CheckIsArrived()
    {
        return (_agent.pathPending == false && _agent.remainingDistance <= _agent.stoppingDistance);
    }

    public void StopRotate()
    {
        isRotate = false;
    }
    public void StartRotate()
    {
        isRotate = true;
    }
    private void RotateToTarget()
    {
        Vector3 direction = Target - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // 회전 각도 보간
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _enemyController.EnemySoData.weaponData.rotateSpeed * Time.deltaTime);
    }
    private void MoveToTarget()
    {
        _agent.SetDestination(Target);
    }
    private void Update()
    {
        if (isSetActive)
        {
            if (isMove) MoveToTarget();
            if (isRotate) RotateToTarget();
        }
    }
}