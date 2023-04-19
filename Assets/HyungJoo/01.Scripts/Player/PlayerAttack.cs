using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PlayerAttack : AgentAttack{
    [SerializeField] private float _attackRadius = 1f, _attackRadiusPlus = 0.5f;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private AttackDamageSO _damageSO;

    public UnityEvent<Vector3,Vector3> OnAttack;

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
        TimeController.Instance.SetTimeScale(1f,true);
        _swordAnimator.OnAttackAnimation();

        Vector3 startPos = transform.position - transform.forward * _attackRadius;
        RaycastHit hit;
        bool isHit = Physics.SphereCast(startPos,_attackRadius, transform.forward,out hit,_attackRadius + _attackRadiusPlus,_enemyLayer);
        if(isHit){
            if(hit.collider.gameObject.TryGetComponent<AgentHP>(out AgentHP hp)){
                hp.Damaged(_damageSO.normalAttack);
                _actionData.hitPos = hit.point;
                _actionData.hitNormal = hit.normal;

                OnAttack?.Invoke(hit.point,hit.normal);
            }
        }
    }
}
