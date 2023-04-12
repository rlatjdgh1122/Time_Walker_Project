using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AgentInput : MonoBehaviour
{
    public event Action OnFireButtonPress;
    public event Action<Vector3> OnMovementKeyPress;
    public event Action<float> OnDashButtonPress;

    private float _timer = 0f;
    private void Update() {
        InputFireButton();
        InputMovementKeyPress();
        InputDashPress();
    }

    private void InputDashPress(){
        if(Input.GetKey(KeyCode.Space)){
            _timer += Time.fixedDeltaTime;
            _timer = Mathf.Clamp(_timer,0,2f);
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            Debug.Log(_timer);
            if(_timer > 0.7f){
                OnDashButtonPress?.Invoke(_timer);
            }
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
