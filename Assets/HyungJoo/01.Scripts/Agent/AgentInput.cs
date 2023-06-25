using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class AgentInput : MonoBehaviour{
    public event Action OnFireButtonPress;
    public event Action<Vector3> OnMovementKeyPress;
    public event Action<float> OnDashButtonPress;
    public event Action<float> OnSlashButtonPress;


    protected AgentAnimator _agentAnimator;
    protected CameraHandler _cameraHandler;
    protected PlayerActionData _actionData;
    protected AgentMovement _agentMovement;

    [SerializeField]
    protected SkillDelaySO _skillDelay;
    private float _dashTimer = 0f;
    private float _slashTimer = 0f;

    private void Awake() {
        _agentAnimator = GetComponent<AgentAnimator>();
        _actionData = transform.Find("ActionData").GetComponent<PlayerActionData>();
        _agentMovement = GetComponent<AgentMovement>();
        _cameraHandler = GetComponent<CameraHandler>();
    }

    private void Update() {
        InputFireButton();
        InputMovementKeyPress();
        InputDashPress();
        InputSlashPress();
    }
    //슬래쉬의 파워가 제대로 적용되지 않는 것 같음
    private void InputSlashPress() {
        if (_actionData.canSlash == false) return;
        if (_actionData.isAttacking) return;

        Action slash = () => {
            _actionData.isSlashing = true;
            _agentAnimator.SlashAnimation(true);
            _agentAnimator.SetSlashBool(false);
            _actionData.chargingSlash = false;
            _slashTimer = 0f;
            StartCoroutine(SlashDelayCor(_skillDelay.slashDelay));
        };

        if (Input.GetMouseButton(1)) {
            _slashTimer += Time.unscaledDeltaTime;
            _slashTimer= Mathf.Clamp(_slashTimer, 0,2f);

            _agentAnimator.SetSlashBool(true);
            _actionData.chargingSlash = true;
            _agentMovement.StopImmediately();
            if(_slashTimer> 1.3f) {
                slash();
                return;
            }
        }
        if (Input.GetMouseButtonUp(1)) {
            if(_slashTimer > 1f) {
                slash();
                return;
            }
            _agentAnimator.SetSlashBool(false);
            _actionData.chargingSlash = false;
            _slashTimer = 0f;
            StartCoroutine(SlashDelayCor(_skillDelay.slashDelay));
        }
    }

    //쿨타임 구현하려면 딜레이 형식을 while 문 형식으로 바꿔야 함
    IEnumerator SlashDelayCor(float timer) {
        _actionData.canSlash = false;
        yield return new WaitForSeconds(timer);
        _actionData.canSlash = true;
        _slashTimer = 0f;
    }
    IEnumerator DashDelayCor(float timer) {
        _actionData.canDash = false;
        yield return new WaitForSeconds(timer);
        _actionData.canDash = true;
        _dashTimer = 0f;
    }

    private void InputDashPress(){
        if(_actionData.canDash == false) return;
        if (_actionData.isAttacking) return;
        if(Input.GetKey(KeyCode.Space)){
            _dashTimer += Time.unscaledDeltaTime;
            _dashTimer = Mathf.Clamp(_dashTimer,0,2f);
            //_animator.SetDashBool(true);
            _cameraHandler.CameraZoom(_dashTimer);
            //_actionData.isAttacking = true;
            _actionData.chargingDash = true;
            _agentMovement.StopImmediately();
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            Debug.Log(_dashTimer);
            //_animator.SetDashBool(false);
            if(_dashTimer > 0.7f){
                OnDashButtonPress?.Invoke(_dashTimer);
                _actionData.isDashing = true;
                StartCoroutine(DashDelayCor(_skillDelay.dashDelay));
            }
            _cameraHandler.ResetCamera();
            _dashTimer = 0f;
            _actionData.chargingDash = false;
        }
    }

    private void InputMovementKeyPress(){
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, 0, v);
        OnMovementKeyPress?.Invoke(direction);
    }


    private void InputFireButton(){
        if (_actionData.isAttacking == true) return;
        if (Input.GetMouseButton(0)){ 
            OnFireButtonPress?.Invoke();
        }
    }
    public void OnSlashStarted(){
        OnSlashButtonPress?.Invoke(_slashTimer);
        _slashTimer = 0f;

    }
}
