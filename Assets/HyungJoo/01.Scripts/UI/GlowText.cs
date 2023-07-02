using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Unity.VisualScripting;

public class GlowText : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TMP_FontAsset _fontAsset;

    public void SetText(string result) {
        _text.SetText(result);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            ShowingSequence(1.5f);
        }
    }

    [ContextMenu("ShowingSequence")]
    public void ShowingSequence(float scaleValue) {
        _text.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
        //_text
        //_text.material.
        _text.transform.DOScale(Vector3.one,2f).SetEase(Ease.OutQuad);
    }


}