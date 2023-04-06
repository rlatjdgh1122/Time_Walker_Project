using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : AgentAttack
{
    private SwordAnimator _swordAnimator;
    private void Awake() {
        _swordAnimator = transform.Find("MainCam").Find("Weapon").Find("Sword").GetComponent<SwordAnimator>();
        isAttacking = false;
    }

    public void TryToAttack()
    {
        if(!isAttacking)
        {
            SwordAttack();
        }
    }

    private void SwordAttack()
    {
        TimeController.Instance.SetTimeScale(1f,true);
        isAttacking = true;
        _swordAnimator.OnAttackAnimation();
    }
}
