using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;   

public class AgentAnimator : MonoBehaviour{
    protected Animator _animator;
    protected PlayerActionData _actionData;
    protected Transform _agentTransform;
    public event Action OnAttackAnimationEndTrigger;

    protected readonly int _attackHash = Animator.StringToHash("ATTACK");
    protected readonly int _speedHash = Animator.StringToHash("SPEED");
    protected readonly int _attackBoolHash = Animator.StringToHash("IS_ATTACK");
    protected readonly int _slashBoolHash = Animator.StringToHash("IS_SLASH");
    protected readonly int _slashHash = Animator.StringToHash("SLASH");

    protected virtual void Awake(){
        _animator = transform.GetComponent<Animator>();
        _agentTransform = GetComponentInParent<AgentMovement>().transform;
        _actionData = transform.parent.Find("ActionData").GetComponent<PlayerActionData>();
    }
    public void SetSpeed(float value) {
        _animator.SetFloat(_speedHash, value);
    }
    public void OnAttackAnimation() {
        _animator.speed = 2f;
        _animator.SetTrigger(_attackHash);
        _animator.SetBool(_attackBoolHash, true);
    }
    public void OnAttackAnimationEnd() {
        _animator.speed = 1f;

        OnAttackAnimationEndTrigger?.Invoke();
        _actionData.isAttacking = false;
        _animator.SetBool(_attackBoolHash, false);
        _animator.ResetTrigger(_attackHash);
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
            _animator.SetTrigger(_slashHash);
        }
        else{
            _animator.ResetTrigger(_slashHash);
        }
    }
}                
