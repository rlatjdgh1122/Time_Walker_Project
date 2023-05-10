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

    private float _dashTimer = 0f;
    private float _slashTimer = 0f;

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
        _agentInput.OnSlashButtonPress += Slash;
    }
    
    public void Dash(float power){
        _actionData.isAttacking = true;
        StartCoroutine(DashCorotuine(power));
        RaycastHit hit;
        bool isHit = Physics.BoxCast(transform.position,transform.lossyScale * 2f,transform.forward,out hit,Quaternion.identity,5f * power, whatIsEnemy);
        if(isHit){
            if(hit.collider.transform.root.gameObject.TryGetComponent<EnemyHit>(out EnemyHit hp)){
                hp.OnCut_Hor();
            }
        }
    }
    [ContextMenu("Slash")]
    public void Slash(float power) {
        GroundSlash gs = PoolManager.Instance.Pop("SlashVFX") as GroundSlash;
        gs.transform.position = transform.position + new Vector3(0,0,0.5f);
        StartCoroutine(SlashDelayCor(5f));
        RaycastHit[] cols = Physics.BoxCastAll(transform.position,transform.lossyScale * 2f,transform.forward,Quaternion.identity,5f * 2f, whatIsEnemy);
        foreach(var hit in cols){
            if(hit.collider.transform.root.gameObject.TryGetComponent<EnemyHit>(out EnemyHit hp)){
                hp.OnCut_Ver();
            }
        }
        gs.rb.AddForce(MainCam.transform.forward * 1000f * power + transform.position);
        gs.actionData = _actionData;

        _actionData.isAttacking = true;
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
        while(_dashTimer < timer){
            _dashTimer += Time.deltaTime;
            yield return null;
        }
        _actionData.canDash =  true;
        _dashTimer = 0f;
    }

    IEnumerator SlashDelayCor(float timer) {
        _actionData.canSlash = false;
        while(_slashTimer < timer) {
            _slashTimer += Time.deltaTime;
            yield return null;
        }
        _actionData.canSlash = true;
        _slashTimer = 0f;
    }

    public float GetTimer(){
        return _dashTimer / _skillDelay.dashDelay;
    }
    public float GetSlashTimer(){
        return _slashTimer / _skillDelay.slashDelay;
    }
}