using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimator : AgentAnimator{
    private readonly int _attackHash = Animator.StringToHash("attack");
    private readonly int _isAttackHash = Animator.StringToHash("IS_ATTACK");

    private readonly int _dashBoolHash = Animator.StringToHash("IS_DASH");
    private readonly int _dashTriggerhash = Animator.StringToHash("dash");

    private PlayerAttack _playerAttack;
    private AttackState _attackState;
    private AgentMovement _movement;
    private PlayerActionData _actionData;

    protected override void Awake(){
        base.Awake();
        _playerAttack = _agentTransform.GetComponentInParent<PlayerAttack>();
        _attackState = _agentTransform.Find("States").GetComponent<AttackState>();
        _movement = _agentTransform.GetComponent<AgentMovement>();
        _actionData = _agentTransform.Find("ActionData").GetComponent<PlayerActionData>();
    }
    
    public void OnAttackAnimation(){
        _animator.SetTrigger(_attackHash);
        _animator.SetBool(_isAttackHash, true);
    }

    public void EndAttackAnimation(){
        _playerAttack.OnAnimationEnd?.Invoke();
        _actionData.isAttacking = false;
        _animator.SetBool(_isAttackHash, false);
        _attackState.SetKeyDelay(0.5f);
        TimeController.Instance.SetTimeScale(0.1f,false);
    }

    public void SetTriggerAttack(bool value){
        if(!value){
            _animator.ResetTrigger(_attackHash);
            _animator.SetBool(_isAttackHash, value);
        }
        else{
            _animator.SetTrigger(_attackHash);
            _animator.SetBool(_isAttackHash, value);
        }
    }

    public void SetDashBool(bool value){
        _animator.SetBool(_dashBoolHash,value);
    }

    public void DashAnimation(bool value){
        if(value){
            _animator.SetTrigger(_dashTriggerhash);
        }else{
            _animator.ResetTrigger(_dashTriggerhash);
        }
    }

    public void AttackAnimationMove(){
        _movement.SetMovementVelocity(Vector3.forward);
    }

}
