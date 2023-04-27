using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour{
    private Slider _hpSlider;

    private void Awake() {
        _hpSlider = GetComponent<Slider>();
        SetSliderValue(1f);
    }
    private void Start() {
        
    }

    public void SetSliderValue(float value){
        _hpSlider.value = value;
    }
}