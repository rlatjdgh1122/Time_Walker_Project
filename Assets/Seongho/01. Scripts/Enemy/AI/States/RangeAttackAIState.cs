using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RangeAttackAIState : CommonAIState
{
    public float motionDelay = 1;
    protected bool _isActive = false;

    private float _lastAtkTime;
    public override void OnEnterState()
    {

        _enemyAnimationController.OnPreEventTrigger += currentWeapon.Shooting;
        _enemyAnimationController.OnPreEndEventTrigger += AttackAnimationEndHandle;

        _enemyMovement.IsMove = false;
        _enemyMovement.IsRotate = false;
        _isActive = true;
    }

    public override void OnExitState()
    {
        _enemyAnimationController.OnEndEventTrigger -= currentWeapon.Shooting;
        _enemyAnimationController.OnPreEventTrigger -= AttackAnimationEndHandle;

        _enemyMovement.IsMove = true;
        _enemyMovement.IsRotate = true;
        _aiActionData.IsAttacking = false;
        _isActive = false;
    }
    private IEnumerator DelayCoroutine(Action Callback, float time)
    {
        yield return new WaitForSeconds(time);
        Callback?.Invoke();
    }

    private void AttackAnimationEndHandle()
    {
        Debug.Log("애니메이션 끝");
        _enemyAnimationController.SetShooting(false);
        _lastAtkTime = Time.time;
        StartCoroutine(DelayCoroutine(() => _aiActionData.IsAttacking = false, _enemyController.weaponSOData.attackDelay));
    }

    public override bool UpdateState()
    {
        if (base.UpdateState())
        {
            return true;
        }
        if (_aiActionData.IsAttacking == false && _isActive)  //액티브
        {
            _enemyMovement.IsRotate = true;
            if (_enemyMovement.IsLookTarget == true && _lastAtkTime +
                _enemyController.enemySOData.AttackDelay < Time.time)
            {
                Debug.Log("공격");
                _aiActionData.IsAttacking = true;
                _enemyAnimationController.SetShooting(true);
            }
        }
        else
            _enemyMovement.IsRotate = false;
        return false;
    }
}
