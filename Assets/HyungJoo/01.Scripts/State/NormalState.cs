using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Define;

public class NormalState : CommonState{
    public override void OnEnterState()
    {
        _agentInput.OnMovementKeyPress += OnMovementHandle;
        _agentInput.OnFireButtonPress += OnAttackHandle;
    }

    public override void OnExitState(){
        _agentInput.OnMovementKeyPress -= OnMovementHandle;
        _agentInput.OnFireButtonPress -= OnAttackHandle;
    }

    public override void UpdateState(){
        Debug.Log("normalState");
    }

    public void OnMovementHandle(Vector3 dir){
        if(_actionData.isAttacking == true) return;
        _agentMovement.SetMovementVelocity(dir);
    }

    public void OnAttackHandle(){
        _agentController.ChangeState(StateType.Attack);
    }
}
