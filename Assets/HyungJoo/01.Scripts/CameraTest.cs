using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour{
    private GlitchEffect _glitchEffect;

    private void Awake() {
        _glitchEffect = GetComponent<GlitchEffect>();
    }


    private void Update() {
        if(Input.GetKeyDown(KeyCode.T)){
            //_glitchEffect.OnRenderImage();
        }
    }


}