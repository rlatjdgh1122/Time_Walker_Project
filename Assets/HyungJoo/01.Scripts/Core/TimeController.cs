using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour{
    public static TimeController Instance;
    private Transform _parentTransform;

    private float _timer;
    public bool canPlusTimer;

    private float _maxValue = 3f;
    private void Awake() {
        Instance = this;
        _timer = _maxValue;
        SetTimeScale(1f,true);

    }

    private void Update() {
        _timer = Mathf.Clamp(_timer,0f,_maxValue);
        if(canPlusTimer){
            _timer += Time.unscaledDeltaTime;
        }
        else{
            _timer -= Time.unscaledDeltaTime;
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
