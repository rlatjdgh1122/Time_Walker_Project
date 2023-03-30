using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Define;
public class AttackState : CommonState
{
    private AgentAttack _agentAttack;

    public override void SetUp(Transform agentTransform)
    {
        base.SetUp(agentTransform);
        _agentAttack = agentTransform.GetComponent<AgentAttack>();
    }

    public override void OnEnterState()
    {
        _agentInput.OnFireButtonPress += AgentAttackHandle;
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
        _agentAttack.TryToAttack();
        Invoke("OnNormalState", 3f);
    }

    public void OnNormalState()
    {
        _agentController.ChangeState(StateType.Normal);
    }
}
