using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Define;
public class SwordAnimator : AgentAnimator{
    private readonly int _attackHash = Animator.StringToHash("attack");
    private readonly int _isAttackHash = Animator.StringToHash("IS_ATTACK");

    private readonly int _dashBoolHash = Animator.StringToHash("IS_DASH");
    private readonly int _dashTriggerhash = Animator.StringToHash("dash");

    private readonly int _slashBoolHash = Animator.StringToHash("IS_SLASH");
    private readonly int _slashTriggerHash = Animator.StringToHash("slash");

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
        Debug.LogError("EndAttackAnimation");
        _playerAttack.OnAnimationEnd?.Invoke();
        _actionData.isAttacking = false;
        _animator.SetBool(_isAttackHash, false);
        //SetTriggerAttack(false);
        _attackState.SetKeyDelay(0.5f);
    }
    public void EndSlashAnimation() {
        SlashAnimation(false);
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
    public void SetSlashBool(bool value) {
        _animator.SetBool(_slashBoolHash,value);
    }
    public void SlashAnimation(bool value) {
        if (value) {
            _animator.SetTrigger(_slashTriggerHash);
        }
        else {
            _animator.ResetTrigger(_slashTriggerHash);
        }
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
