using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Define;
public class TimeController : MonoBehaviour{
    public static TimeController Instance;
    private Transform _parentTransform;
    private PlayerActionData _actionData;
    private Transform _player;

    private float _maxValue = 3f;
    private void Awake() {
        Instance = this;
        _player = FindObjectOfType<AgentController>().GetComponent<Transform>();
        SetTimeScale(1f);
        _actionData = _player.Find("ActionData").GetComponent<PlayerActionData>();
    }

    private void FixedUpdate(){

        if(_actionData.isAttacking){
            if(_actionData.chargingDash){
                SetTimeScale(0.1f);
                Debug.Log("CharingDash");
                return;
            }
            else if (_actionData.isDashing){
                SetTimeScale(1f);
            }
            else{
                SetTimeScale(1f);
                return;
            }
        }
        else if(_actionData.isMoving){
            SetTimeScale(1f);
        }
        else if(_actionData.isMoving == false){
            SetTimeScale(0.1f);
        }
    }

    public void SetTimeScale(float timeScale){
        Time.timeScale = timeScale;
    }
}
