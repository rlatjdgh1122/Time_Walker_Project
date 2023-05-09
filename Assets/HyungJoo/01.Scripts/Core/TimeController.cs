using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Define;
public class TimeController : MonoBehaviour{
    public static TimeController Instance;
    private Transform _parentTransform;
    private PlayerActionData _actionData;
    private Transform _player;
    private float _timer;
    public bool canPlusTimer;

    private float _maxValue = 3f;
    private void Awake() {
        Instance = this;
        _player = FindObjectOfType<AgentController>().GetComponent<Transform>();
        _timer = _maxValue;
        SetTimeScale(1f,true);
        _actionData = _player.Find("ActionData").GetComponent<PlayerActionData>();
    }

    private void Update() {
        Debug.Log("Can Plus Timer: " + canPlusTimer);
        if(canPlusTimer){
            _timer += Time.unscaledDeltaTime;
        }
        else{
            _timer -= Time.unscaledDeltaTime;
        }
        _timer = Mathf.Clamp(_timer,0f,_maxValue);
    }
    private void FixedUpdate(){

        if(_actionData.isAttacking){
            if(_actionData.chargingDash){
                SetTimeScale(0.1f,false);
                Debug.Log("CharingDash");
                return;
            }
            else{
                SetTimeScale(1f,false);
                return;
            }
        }
        else if(_actionData.isMoving){
            SetTimeScale(1f,true);
        }
        else if(_actionData.isMoving == false){
            if(_timer <= 0.005f){
                SetTimeScale(1f,false);
                return;
            }
            SetTimeScale(0.1f,false);
        }
    }

    public void SetTimeScale(float timeScale,bool canPlusTimer){
        Time.timeScale = timeScale;
        this.canPlusTimer = canPlusTimer;
    }

    public float GetCurrentTime(){
        return _timer / _maxValue;
    }
}
