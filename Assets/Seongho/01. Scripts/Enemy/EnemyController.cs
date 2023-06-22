using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public CommonAIState _currentState;
    public EnemySOData enemySOData;
    public WeaponSOData weaponSOData;
    public Transform weaponPivot;

    public IWeaponable currentWeapon;

    private List<AITransition> _anyTransitions = new List<AITransition>();
    public List<AITransition> AnyTransitions => _anyTransitions;

    private string cooltimeName = "EnemyAttackCoolTime";

    private Transform _targetTrm;
    public Transform TargetTrm => _targetTrm;

    private Animator _animator;
    private void Awake()
    {
        List<CommonAIState> states = new List<CommonAIState>();
        transform.Find("AI").GetComponentsInChildren<CommonAIState>(states);

        states.ForEach(s => s.SetUp(transform));
        /*  _actionData = transform.Find("AI").GetComponent<AIActionData>();
          _initState = _currentState;*/

        _animator = GetComponent<Animator>();


    }
    private void Start()
    {
        _targetTrm = GameManager.Instance.PlayerTrm;
        SpawnWeapon();
        ChangeState(_currentState);
    }
    private void SpawnWeapon() //√— º“»Ø
    {
        Weapon weapon = WeaponManager.Instance.SpawnWeapon(weaponSOData.WeaponName);
        GameObject g = Instantiate(weapon.gameObject, weaponPivot);
        currentWeapon = g.GetComponent<Weapon>();
        Debug.Log(g);

        _animator.runtimeAnimatorController = weaponSOData.animatiorController;
    }

    public void ChangeState(CommonAIState nextState)
    {
        _currentState?.OnExitState();
        _currentState = nextState;
        _currentState?.OnEnterState();
    }
    void Update()
    {
        _currentState?.UpdateState();
    }

}
