using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static Core.Define;

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

    public void TryDash(){
        
    }

    private void SwordAttack(){
        _actionData.isAttacking = true;
        _swordAnimator.OnAttackAnimation();

    }

}
