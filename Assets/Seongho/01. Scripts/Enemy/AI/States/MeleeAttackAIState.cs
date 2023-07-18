using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeAttackAIState : CommonAIState
{
    public float motionDelay = 1;
    protected bool _isActive = false;

    private float _lastAtkTime;

    [SerializeField]
    private UnityEvent OnStart = null;
    [SerializeField]
    private UnityEvent OnDamaged = null;
    [SerializeField]
    private UnityEvent OnDamagedStop = null;
    public override void OnEnterState()
    {
        _enemyAnimationController.OnStartEventTrigger += AttackAnimationStartHandle;
        _enemyAnimationController.OnPreEventTrigger += AttackAnimationPreHandle;
        _enemyAnimationController.OnEndEventTrigger += AttackAnimationEndHandle;
        _enemyAnimationController.OnPreEndEventTrigger += AttackAnimationPreEndHandle;
        _enemyMovement.IsMove = false;
        _enemyMovement.IsRotate = false;
        _isActive = true;
    }

    private void AttackAnimationStartHandle()
    {
        OnStart?.Invoke();
    }

    private void AttackAnimationPreEndHandle()
    {
        OnDamagedStop?.Invoke();
    }

    private void AttackAnimationPreHandle()
    {
        SoundManager.Instance.PlaySoundName("�ֵθ���");
        OnDamaged?.Invoke();
    }

    private void AttackAnimationEndHandle()
    {

        _enemyAnimationController.SetShooting(false);
        _lastAtkTime = Time.time;
        StartCoroutine(DelayCoroutine(() => _aiActionData.IsAttacking = false, _enemyController.weaponSOData.attackDelay));
    }

    private IEnumerator DelayCoroutine(Action Callback, float time)
    {
        yield return new WaitForSeconds(time);
        Callback?.Invoke();
    }
    public override void OnExitState()
    {
        _enemyAnimationController.OnStartEventTrigger -= AttackAnimationStartHandle;
        _enemyAnimationController.OnEndEventTrigger -= AttackAnimationEndHandle;
        _enemyAnimationController.OnPreEventTrigger -= AttackAnimationPreHandle;
        _enemyAnimationController.OnPreEndEventTrigger -= AttackAnimationPreEndHandle;

        _enemyMovement.IsMove = true;
        _enemyMovement.IsRotate = true;

        _aiActionData.IsAttacking = false;
        _isActive = false;
    }

    public override bool UpdateState()
    {
        if (base.UpdateState())
        {
            return true;
        }
        if (_aiActionData.IsAttacking == false && _isActive)  //��Ƽ��
        {
            _enemyMovement.IsRotate = true;
            if (_enemyMovement.IsLookTarget == true && _lastAtkTime + _enemyController.weaponSOData.attackDelay < Time.time)
            {
                _aiActionData.IsAttacking = true;
                _enemyAnimationController.SetShooting(true);
            }
        }
        else
            _enemyMovement.IsRotate = false;
        return false;
    }
}
