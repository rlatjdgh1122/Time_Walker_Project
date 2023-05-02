using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static Core.Define;

public class PlayerAttack : AgentAttack{
    private SwordAnimator _swordAnimator;
    [SerializeField]
    private Vector3 _offset;
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
        RaycastHit hit;
        bool result = Physics.SphereCast(transform.position + _offset, 3f,MainCam.transform.forward,out hit, 10f);
        if (result) {
            Debug.Log($"{hit.collider.gameObject.name} - ColliderName");
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + MainCam.transform.forward + _offset, 1f);
    }
}
