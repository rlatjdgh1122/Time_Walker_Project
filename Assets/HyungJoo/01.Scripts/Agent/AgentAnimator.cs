using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;   

public class AgentAnimator : MonoBehaviour{
    protected Animator _animator;
    protected PlayerActionData _actionData;
    protected Transform _agentTransform;
    
    public event Action OnAttackAnimationEndTrigger;
    public event Action OnSlashEndTrigger;
    public event Action OnComboAnimationEndTrigger;

    protected readonly int _attackHash = Animator.StringToHash("ATTACK");
    protected readonly int _attackBoolHash = Animator.StringToHash("IS_ATTACK");

    protected readonly int _speedHash = Animator.StringToHash("SPEED");

    protected readonly int _slashBoolHash = Animator.StringToHash("IS_SLASH");
    protected readonly int _slashTriggerHash = Animator.StringToHash("SLASH");

    protected readonly int _dashBoolHash = Animator.StringToHash("IS_DASH");
    protected readonly int _dashTriggerHash = Animator.StringToHash("DASH");

    protected virtual void Awake(){
        _animator = transform.GetComponent<Animator>();
        _agentTransform = transform.root.GetComponent<AgentMovement>().transform;
        _actionData = transform.root.Find("ActionData").GetComponent<PlayerActionData>();
    }
    public void SetSpeed(float value) {
        _animator.SetFloat(_speedHash, value);
    }


    public void SetAttackTrigger(bool result) {
        if (result) {
            _animator.SetTrigger(_attackHash);
        }
        else {
            _animator.ResetTrigger(_attackHash);
        }
    }

    public void SetSlashBool(bool result){
        _animator.SetBool(_slashBoolHash,result);
    }
    
    public void SlashAnimation(bool result){
        if(result){
            _animator.SetTrigger(_slashTriggerHash);
        }
        else{
            _animator.ResetTrigger(_slashTriggerHash);
        }
    }
    public void SetDashBool(bool result){
        _animator.SetBool(_dashBoolHash,result);
    }
    public void DashAnimation(bool result){
        if(result){
            _animator.SetTrigger(_dashTriggerHash);
        }
        else{
            _animator.ResetTrigger(_dashTriggerHash);
        }
    }




    public void OnAttackAnimation() {
        _animator.speed = 2f;
        _animator.SetTrigger(_attackHash);
        _animator.SetBool(_attackBoolHash, true);
    }
    public void OnAttackAnimationEnd() {
        _animator.speed = 1f;

        OnAttackAnimationEndTrigger?.Invoke();
        //SetAllParameters(false);
        _actionData.isAttacking = false;
        _animator.SetBool(_attackBoolHash, false);
        _animator.ResetTrigger(_attackHash);
    }

    public void OnComboAnimationEnd() {
        Debug.Log("OnComboAnimationEnd");
        OnComboAnimationEndTrigger?.Invoke();
        _animator.SetBool(_attackBoolHash, false);
        _animator.ResetTrigger(_attackHash);
        SetAllParameters(false);
    }
    public void OnSlashEnd() {
        OnSlashEndTrigger?.Invoke();
        _actionData.isSlashing = false;
        DashAnimation(false);
        Debug.Log("OnSlashEnd");
    }

    private void SetAllParameters(bool result) {
        _actionData.isAttacking = result;
        _actionData.isDashing = result;
        _actionData.isSlashing = result;
    }
}                
