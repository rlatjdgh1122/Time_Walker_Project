using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : AgentAttack{
    private SwordAnimator _swordAnimator;

    private void Awake() {
        _swordAnimator = GetComponentInChildren<SwordAnimator>();
        isAttacking = false;
    }

    public void TryToAttack(){
        if(!isAttacking){
            SwordAttack();
        }
    }

    private void SwordAttack(){
        TimeController.Instance.SetTimeScale(1f,true);
        isAttacking = true;
        _swordAnimator.OnAttackAnimation();

    }
}
