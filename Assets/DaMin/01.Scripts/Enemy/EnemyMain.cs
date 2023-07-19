using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyState { idle = 0, chase, attack }
public class EnemyMain : MonoBehaviour
{
    [Header("AI Setting")]
    [Range(0.1f, 50f)] public float _moveSpeed;
    [Range(0.1f, 50f)] public float _damage;
    [Range(0.01f, 10f)][Tooltip("공격 쿨타임")] public float _timeToBtweenShot;
    [Range(0f, 50f)][Tooltip("인식 범위 0은 무한")][SerializeField] private float _range = 0;
    [Range(0f, 50f)][Tooltip("공격 범위")] public float _attackRange = 0;
    [SerializeField][Tooltip("적 레이어")] private LayerMask _whatIsEnemy;


    [HideInInspector]
    public NavMeshAgent _agent;
    [HideInInspector]
    public Animator _animator;


    [HideInInspector]
    public Transform _curTarget;
    public Transform CurrentTarget
    {
        set => _curTarget = value;
        get => _curTarget;
    }


    [HideInInspector]
    public EnemyState _curState;
    private State<EnemyMain>[] _states;
    private StateMachine<EnemyMain> _stateMachine;

    private EnemyState CurState
    {
        get => _curState;
        set => _curState = value;
    }

    private void Awake()
    {
        _states = new State<EnemyMain>[3];
        _states[(int)EnemyState.idle] = new EnemyStates.Idle();
        _states[(int)EnemyState.chase] = new EnemyStates.Chase();
        _states[(int)EnemyState.attack] = new EnemyStates.Attack();
        _stateMachine = new StateMachine<EnemyMain>();
        _stateMachine.Setup(this, _states[(int)EnemyState.idle]);

        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _stateMachine.Execute();
    }

    public void ChangeState(EnemyState _state)
    {
        _curState = _state;
        _stateMachine.ChangeState(_states[(int)_state]);
    }

    public void FindTarget()
    {
        Collider[] _cols = Physics.OverlapSphere(transform.position, _range == 0 ? Mathf.Infinity : _range, _whatIsEnemy);
        Transform Target = transform;

        float minDistance = Mathf.Infinity;

        for (int i = 0; i < _cols.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, _cols[i].transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                Target = _cols[i].transform;
            }
        }
        _curTarget = Target;

        Debug.Log($"current target is {_curTarget.gameObject.name}");
    }
}
