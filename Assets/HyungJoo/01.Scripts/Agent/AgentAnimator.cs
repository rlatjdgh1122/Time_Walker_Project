using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimator : MonoBehaviour{
    protected Animator _animator;
    protected PlayerActionData _actionData;
    protected Transform _agentTransform;

    protected readonly int _attackHash = Animator.StringToHash("ATTACK");
    protected readonly int _speedHash = Animator.StringToHash("SPEED");

    protected virtual void Awake(){
        _animator = transform.GetComponent<Animator>();
        _agentTransform = GetComponentInParent<AgentMovement>().transform;
        _actionData = transform.parent.Find("ActionData").GetComponent<PlayerActionData>();
    }
    public void SetSpeed(float value) {
        _animator.SetFloat(_speedHash, value);
    }
    public void OnAttackAnimation() {
        _animator.SetTrigger(_attackHash);
    }
    public void OnAttackAnimationEnd() {
        _animator.ResetTrigger(_attackHash);
        _actionData.isAttacking = false;
    }
}                
