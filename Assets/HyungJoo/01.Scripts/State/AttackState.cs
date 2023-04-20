using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Define;
public class AttackState : CommonState {
    private PlayerAttack _playerAttack;
    private int _attackCombo = 0;
    private float _keyTimer = 0f;

    public override void SetUp(Transform agentTransform){
        base.SetUp(agentTransform);
        _playerAttack = agentTransform.GetComponent<PlayerAttack>();
        _playerAttack.OnAnimationEnd.AddListener(() => OnNormalState());
        _actionData.isAttacking = true;
    }

    public override void OnEnterState(){
        _agentInput.OnFireButtonPress += AgentAttackHandle;
        _agentMovement.StopImmediately();
        _attackCombo = 0;
        _actionData.isAttacking = false;
    }

    public override void OnExitState() {
        _agentInput.OnFireButtonPress -= AgentAttackHandle;
        _attackCombo = 0;
    }

    public override void UpdateState(){
        if(!_actionData.isAttacking && _keyTimer > 0f){
            _keyTimer -= Time.deltaTime;
            if(_keyTimer <= 0f){
                _agentController.ChangeState(StateType.Normal);
                SwordAnimator animator = _agentAnimator as SwordAnimator;
                animator.SetTriggerAttack(false);
            }
        }
    }

    public void SetKeyDelay(float value){
        _keyTimer = value;
    }
    public void AgentAttackHandle() {
        if(!_actionData.isAttacking && _attackCombo < 3){            
            _playerAttack.TryToAttack();
            _attackCombo++;
        }
    }
    public void AgentDashHandle(){
        if(!_actionData.isAttacking){
            _playerAttack.TryDash();
        }
    }

    public void OnNormalState() {
        _agentController.ChangeState(StateType.Normal);
    }
}
