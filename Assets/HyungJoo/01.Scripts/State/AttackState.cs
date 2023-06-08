using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Define;
using System;
using UnityEngine.Events;
public class AttackState : CommonState {
    private PlayerAttack _playerAttack;
    private int _attackCombo;
    private float _keyTimer = 0f;

    public event Action<int> OnAttackAnimation;

    public override void SetUp(Transform agentTransform){
        base.SetUp(agentTransform);
        _playerAttack = agentTransform.GetComponent<PlayerAttack>();
        //_playerAttack.OnAnimationEnd.AddListener(() => OnNormalState());
        _actionData.isAttacking = true;
    }

    public override void OnEnterState(){
        _agentInput.OnFireButtonPress += AgentAttackHandle;
        //OnAttackAnimation += PlayParticle;
        _agentMovement.StopImmediately();
        _actionData.isAttacking = false;
        //Debug.Log("OnEnterState");
        _attackCombo = 0;
    }
    public override void OnExitState() {
        _agentInput.OnFireButtonPress -= AgentAttackHandle;
        //OnAttackAnimation -= PlayParticle;
        //Debug.Log("OnExitState");
    }

    public override void UpdateState(){
        if(_actionData.isAttacking == false && _keyTimer > 0f){
            _keyTimer -= Time.deltaTime;
            if(_keyTimer <= 0f){
                _agentController.ChangeState(StateType.Normal);
                _agentAnimator.SetAttackTrigger(false);
                //_attackCombo = 0;
            }
        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x > 0 || y > 0) {
            OnNormalState();
        }
    }


    public void SetKeyDelay(float value){
        _keyTimer = value;
    }

    public void AgentAttackHandle() {
        if(_actionData.isAttacking == false){
            if (_attackCombo >= 3) {
                _attackCombo = 0;
                _agentAnimator.OnAttackAnimationEnd();
                 return;
            }
            _playerAttack.TryToAttack();
            OnAttackAnimation?.Invoke(_attackCombo);
            Debug.Log($"AttackCombo {_attackCombo}");
            _attackCombo++;
            if(_attackCombo >=3 ){
                _attackCombo = 0;
            }
        }
    }

    public void AgentDashHandle(){
        if(!_actionData.isAttacking){
            _playerAttack.TryDash();
        }
    }

    public void OnNormalState() {
        _agentController.ChangeState(StateType.Normal);
    }
    // public void PlayParticle(int count){
    //    PoolableMono pm = PoolManager.Instance.Pop($"Particle{count}");
    //    pm.transform.position = MainCam.transform.position + MainCam.transform.forward;
    //    pm.transform.rotation = MainCam.transform.rotation;
    //}
}
