using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : AgentAttack{
    private SwordAnimator _swordAnimator;

    protected override void Awake() {
        base.Awake();
        _swordAnimator = GetComponentInChildren<SwordAnimator>();
        _actionData.isAttacking = false;
    }

    public void TryToAttack(){
        if(!_actionData.isAttacking){
            SwordAttack();
        }
    }

    private void SwordAttack(){
        _actionData.isAttacking = true;
        TimeController.Instance.SetTimeScale(1f,true);
        _swordAnimator.OnAttackAnimation();

    }
}
