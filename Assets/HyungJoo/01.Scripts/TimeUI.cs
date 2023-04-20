using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeUI : MonoBehaviour
{
    private Slider _slider;
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update(){
        _slider.value = TimeController.Instance.GetCurrentTime();
        //Debug.Log(TimeController.Instance.GetCurrentTime());
    }
}
