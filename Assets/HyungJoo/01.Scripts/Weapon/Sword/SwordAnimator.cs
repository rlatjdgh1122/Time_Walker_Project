using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimator : AgentAnimator
{
    private readonly int _attackHash = Animator.StringToHash("attack");
    private readonly int _blockHash = Animator.StringToHash("block");
    private PlayerAttack _playerAttack;

    protected override void Awake(){
        base.Awake();
        _playerAttack = transform.parent.GetComponent<PlayerAttack>();
    }
    
    public void OnAttackAnimation(){
        _animator.SetTrigger(_attackHash);
    }

    public void EndAttackAnimation(){
        _playerAttack.OnAnimationEnd?.Invoke();
        _playerAttack.isAttacking = false;
    }

}
