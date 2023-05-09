using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeUI : MonoBehaviour{
    private Slider _slider;
    private Image _timerImage;

    private void Awake(){
        _slider = GetComponent<Slider>();
        _timerImage = transform.Find("TimerImage").GetComponent<Image>();
    }
    private void Update(){
        if(Time.timeScale == 0.1f){
            _timerImage.enabled = true;
        }else{
            _timerImage.enabled = false;
        }
        _slider.value = TimeController.Instance.GetCurrentTime();
    }
}
