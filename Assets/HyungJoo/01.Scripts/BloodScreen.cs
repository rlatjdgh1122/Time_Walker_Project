using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class BloodScreen : MonoBehaviour{
    [SerializeField] private Image _image;

    public void ShowingSequence(){
        StopAllCoroutines();
        StartCoroutine(FadeCor());
    }

    IEnumerator FadeCor()    {
        float fadeValue = 1f;
        Color color = _image.color;

        while(fadeValue <= 1f){
            fadeValue -= Time.deltaTime;
            color.a = fadeValue;
            _image.color = color;
            yield return null;
        }
        yield return null;
    }
}