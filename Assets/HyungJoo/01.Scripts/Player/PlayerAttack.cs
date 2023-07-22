using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static Core.Define;

public class PlayerAttack : AgentAttack {
    private AgentAnimator _agentAnimator;
    [SerializeField]
    private LayerMask _mask;
    [SerializeField]
    private Vector3 _offset;
    protected override void Awake() {
        base.Awake();
        _agentAnimator = GetComponent<AgentAnimator>();
        _actionData.isAttacking = false;
        _agentAnimator.OnAttackAnimationEndTrigger += Attack;
    }
    public void TryToAttack(){
        if(!_actionData.isAttacking && !_actionData.chargingSlash && !_actionData.chargingDash){
            SwordAttack();
        }
    }
    public void TryDash(){
        
    }   
    private void SwordAttack(){
        _actionData.isAttacking = true;
        _agentAnimator.OnAttackAnimation();

    }

    public void Attack()
    {
        RaycastHit hit;
        bool result = Physics.SphereCast(transform.position + _offset, 1f, MainCam.transform.forward, out hit, 1f, _mask);
        if (result)
        {
            Debug.Log($"{hit.collider.gameObject.name} - ColliderName");
            hit.collider.transform.GetComponentInParent<EnemyHit>().OnCut_Hor();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + MainCam.transform.forward + _offset, 1f);
    }
}
