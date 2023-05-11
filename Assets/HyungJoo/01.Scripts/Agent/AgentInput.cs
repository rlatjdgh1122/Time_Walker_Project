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

    protected SwordAnimator _animator;
    protected CameraHandler _cameraHandler;
    protected PlayerActionData _actionData;
    protected AgentMovement _agentMovement;
    private float _dashTimer = 0f;
    private float _slashTimer = 0f;

    private void Awake() {
        _animator = transform.Find("MainCam").Find("WeaponParent").Find("Weapon").GetComponent<SwordAnimator>();
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

    private void InputSlashPress() {
        if (_actionData.canSlash == false) return;
        if (Input.GetMouseButton(1)) {
            _slashTimer += Time.unscaledDeltaTime;
            _slashTimer= Mathf.Clamp(_slashTimer, 0,2f);
            Debug.Log(_slashTimer);
            _animator.SetSlashBool(true);
            _actionData.chargingSlash = true;
            _actionData.isAttacking = true;
            _agentMovement.StopImmediately();
            
        }
        if (Input.GetMouseButtonUp(1)) {
            if(_slashTimer > 1f) {
                OnSlashButtonPress?.Invoke(_slashTimer);
                _actionData.chargingSlash = false;
                _animator.SlashAnimation(true);
            }
            _animator.SetSlashBool(false);
            _actionData.isAttacking = false;
            _slashTimer = 0f;
        }
    }

    private void InputDashPress(){
        if(_actionData.canDash == false) return;
        if(Input.GetKey(KeyCode.Space)){
            _dashTimer += Time.unscaledDeltaTime;
            _dashTimer = Mathf.Clamp(_dashTimer,0,2f);
            _animator.SetDashBool(true);
            _cameraHandler.CameraZoom(_dashTimer);
            _actionData.isAttacking = true;
            _actionData.chargingDash = true;
            _agentMovement.StopImmediately();
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            Debug.Log(_dashTimer);
            _animator.SetDashBool(false);
            if(_dashTimer > 0.7f){
                OnDashButtonPress?.Invoke(_dashTimer);
                _actionData.isDashing = true;
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
        if (Input.GetMouseButton(0)){ 
            OnFireButtonPress?.Invoke();
        }
    }
}
