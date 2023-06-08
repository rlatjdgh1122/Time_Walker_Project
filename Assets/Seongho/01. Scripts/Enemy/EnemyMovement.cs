using Core;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : EnemyAnimationController
{
    private EnemyController _enemyController;
    private NavMeshAgent _agent;
    private bool _isRotate;
    public bool IsRotate { get { return _isRotate; } set { _isRotate = value; } }
    protected override void Awake()
    {
        base.Awake();
        _agent = GetComponent<NavMeshAgent>();
        _enemyController = GetComponent<EnemyController>();
    }

    private void Start()
    {
        SetSpeed(_enemyController.EnemySoData.weaponData.speed);
    }
    private void Update()
    {
        RotateState();
    }
    public void StartImmediately()
    {
        _agent.SetDestination(GameManager.Instance.PlayerTrm.position);
        Debug.Log("������");
    }
    public void SetSpeed(float speed)
    {
        _agent.speed = speed;
    }
    public void StopImmediately()
    {
        _agent.SetDestination(transform.position);
        Debug.Log("����");
    }
    public bool CheckIsArrived()
    {
        return (_agent.pathPending == false && _agent.remainingDistance <= _agent.stoppingDistance);
    }

    public void RotateState()
    {
        if (IsRotate)
        {
            Debug.Log("�������� ��");
            Quaternion rot = Quaternion.LookRotation(GameManager.Instance.PlayerTrm.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, _enemyController.EnemySoData.weaponData.rotateSpeed * Time.deltaTime);
        }
    }
}