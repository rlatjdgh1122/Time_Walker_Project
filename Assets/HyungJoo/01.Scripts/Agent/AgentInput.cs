using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class AgentInput : MonoBehaviour{
    public event Action OnFireButtonPress;
    public event Action<Vector3> OnMovementKeyPress;
    public event Action<float> OnDashButtonPress;

    protected SwordAnimator _animator;
    protected CameraHandler _cameraHandler;
    private float _timer = 0f;

    private void Awake() {
        _animator = transform.Find("MainCam").Find("WeaponParent").Find("Weapon").GetComponent<SwordAnimator>();
        _cameraHandler = GetComponent<CameraHandler>();
    }
    
    private void Update() {
        InputFireButton();
        InputMovementKeyPress();
        InputDashPress();
    }

    private void InputDashPress(){
        if(Input.GetKey(KeyCode.Space)){
            _timer += Time.fixedDeltaTime;
            _timer = Mathf.Clamp(_timer,0,2f);
            TimeController.Instance.SetTimeScale(1f,false);
            _animator.SetDashBool(true);
            _cameraHandler.CameraZoom(_timer);
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            Debug.Log(_timer);
            _animator.SetDashBool(false);
            TimeController.Instance.SetTimeScale(1f,true);
            if(_timer > 0.7f){
                OnDashButtonPress?.Invoke(_timer);
            }
            _cameraHandler.ResetCamera();
            _timer = 0f;
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
