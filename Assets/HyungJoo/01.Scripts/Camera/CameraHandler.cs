using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Define;
public class CameraHandler : MonoBehaviour{

    private float _normalValue;

    private void Awake() {
        _normalValue = MainCam.fieldOfView;
    }

    public void CameraZoom(float value){
        if(value == 0){
            MainCam.fieldOfView = _normalValue;
            return;
        }
        Debug.Log(MainCam.fieldOfView);
        MainCam.fieldOfView = _normalValue + value * 7f;
    }

    public void ResetCamera(){
                    MainCam.fieldOfView = _normalValue;
    }
}