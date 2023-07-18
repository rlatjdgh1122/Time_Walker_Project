using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAIState : CommonAIState
{
    protected Vector3 _targetVector;
    protected bool _isActive = false;

    private float _lastAtkTime;
    private void Start()
    {
        _targetVector = GameManager.Instance.PlayerTrm.position;
    }
    public override void OnEnterState()
    {
        _enemyMovement.StopImmediately();
        _enemyAnimationController.OnEndEventTrigger += AttackAnimationEndHandle;
        _enemyAnimationController.OnPreEventTrigger += AttackAnimationPreHandle;
    }

    private void AttackAnimationPreHandle()
    {
<<<<<<< HEAD:Assets/Seongho/01. Scripts/Enemy/AI/States/MeleeAttackAIState.cs
        SoundManager.Instance.PlaySoundName("�ֵθ���");
        OnDamaged?.Invoke();
=======
        _enemyWeaponController.EventShooting();
>>>>>>> main:Assets/Seongho/01. Scripts/Enemy/AI/States/AttackAIState.cs
    }

    private void AttackAnimationEndHandle()
    {
        _enemyAnimationController.SetShooting(false);
        _lastAtkTime = Time.time; //�������� 1�� ��ٷȴٰ� �ٽ� ������ �߻�
        StartCoroutine(DelayCoroutine(() => _aiActionData.IsAttacking = false, _enemyController.EnemySoData.weaponData.motionDelay));
    }

    private IEnumerator DelayCoroutine(Action Callback, float time)
    {
        yield return new WaitForSeconds(time);
        Callback?.Invoke();
    }
    public override void OnExitState()
    {

        _enemyAnimationController.OnEndEventTrigger -= AttackAnimationEndHandle;
        _enemyAnimationController.OnPreEventTrigger -= AttackAnimationPreHandle;
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
            Vector3 currentFrontVector = transform.forward;
            float angle = Vector3.Angle(currentFrontVector, _targetVector);

            if (angle >= 10f)
            {
                _enemyMovement.IsRotate = true;
            }
            else if (_enemyController.EnemySoData.weaponData.attackCoolTime < Time.time) //��Ÿ�ӵ� á�� ������ 10���� ���Դٸ�
            {
                _aiActionData.IsAttacking = true;
                _enemyAnimationController.SetShooting(true);
            }
        }

        return false;
    }
}
