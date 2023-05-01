using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Define;
using UnityEngine.Events;

public class AgentSkill : MonoBehaviour{
    protected AgentInput _agentInput;
    protected AgentMovement _agentMovement;
    protected AgentAttack _agentAttack;
    protected AgentController _agentController;
    protected PlayerActionData _actionData;
    protected SwordAnimator _animator;

    [SerializeField]
    private SkillDelaySO _skillDelay;

    public UnityEvent OnDashStart;
    public UnityEvent OnDashEnd;

    private float _timer = 0f;

    private void Awake() {
        _agentInput  = GetComponent<AgentInput>();
        _agentMovement = GetComponent<AgentMovement>();
        _agentAttack = GetComponent<AgentAttack>();
        _agentController = GetComponent<AgentController>();
        _animator = transform.Find("MainCam").Find("WeaponParent").Find("Weapon").GetComponent<SwordAnimator>(); 
        _actionData = transform.Find("ActionData").GetComponent<PlayerActionData>();
    }

    private void Update() {
    }

    private void Start() {
        _agentInput.OnDashButtonPress += Dash;
    }
    
    public void Dash(float power){
        _actionData.isAttacking = true;
        StartCoroutine(DashCorotuine(power));
        RaycastHit hit;
        bool isHit = Physics.BoxCast(transform.position,transform.lossyScale,transform.forward,out hit,Quaternion.identity,5f, whatIsEnemy);
        if(isHit){
            if(hit.collider.gameObject.TryGetComponent<AgentHP>(out AgentHP hp)){
                hp.Damaged(5);
            }
        }
    }
    [ContextMenu("Slash")]
    public void Slash() {
        GroundSlash gs = PoolManager.Instance.Pop("SlashVFX") as GroundSlash;
        gs.transform.position = transform.position;
        gs.rb.AddForce(MainCam.transform.forward * 100f);
    }
    IEnumerator DashCorotuine(float power){
        _animator.DashAnimation(true);
        OnDashStart?.Invoke();
        _agentMovement.SetDashVelocity(transform.forward * power);
        yield return new WaitForSeconds(0.15f);
        _agentMovement.StopImmediately();
        OnDashEnd?.Invoke();
        _actionData.isAttacking = false;
        _animator.DashAnimation(false);
        _actionData.isDashing = false;
        StartCoroutine(DelayCor(_skillDelay.dashDelay));
    }

    IEnumerator DelayCor(float timer){
        _actionData.canDash = false;
        while(_timer < timer){
            _timer += Time.unscaledDeltaTime;
            yield return null;
        }
        _actionData.canDash =  true;
        _timer = 0f;
    }

    public float GetTimer(){
        return _timer / _skillDelay.dashDelay;
    }
}