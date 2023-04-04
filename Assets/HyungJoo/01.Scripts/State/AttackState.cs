using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Define;
public class AttackState : CommonState
{
    private PlayerAttack _playerAttack;

    private void Awake() {
        _playerAttack.OnAnimationEnd.AddListener(() => OnNormalState());
    }

    public override void SetUp(Transform agentTransform)
    {
        base.SetUp(agentTransform);
        _playerAttack = agentTransform.GetComponent<PlayerAttack>();
    }

    public override void OnEnterState()
    {
        _agentInput.OnFireButtonPress += AgentAttackHandle;
        _agentMovement.StopImmediately();
    }

    public override void OnExitState()
    {
        _agentInput.OnFireButtonPress -= AgentAttackHandle;
    }

    public override void UpdateState()
    {

    }

    public void AgentAttackHandle()
    {
        _playerAttack.TryToAttack();
    }

    public void OnNormalState()
    {
        _agentController.ChangeState(StateType.Normal);
    }
}
