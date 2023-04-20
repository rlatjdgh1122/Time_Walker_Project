using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSkill : MonoBehaviour{
    protected AgentInput _agentInput;
    protected AgentMovement _agentMovement;
    protected AgentAttack _agentAttack;
    protected AgentController _agentController;
    protected PlayerActionData _actionData;
    protected SwordAnimator _animator;
    
    private void Awake() {
        _agentInput  = GetComponent<AgentInput>();
        _agentMovement = GetComponent<AgentMovement>();
        _agentAttack = GetComponent<AgentAttack>();
        _agentController = GetComponent<AgentController>();
        _animator = transform.Find("MainCam").Find("WeaponParent").Find("Weapon").GetComponent<SwordAnimator>(); 
        _actionData = transform.Find("ActionData").GetComponent<PlayerActionData>();
    }

    private void Start() {
        _agentInput.OnDashButtonPress += Dash;
    }

    public void Dash(float power){
        _actionData.isAttacking = true;
        StartCoroutine(DashCorotuine(power));
        RaycastHit hit;
        bool isHit = Physics.BoxCast(transform.position,transform.lossyScale,transform.forward,out hit,Quaternion.identity,5f);
        if(isHit){
            hit.collider.GetComponent<AgentHP>().Damaged(5);
        }
    }

    IEnumerator DashCorotuine(float power){
        _animator.DashAnimation(true);
        _agentMovement.SetDashVelocity(transform.forward * power);
        yield return new WaitForSeconds(0.15f);
        _agentMovement.StopImmediately();
        _actionData.isAttacking = false;
        _animator.DashAnimation(false);
    }
}