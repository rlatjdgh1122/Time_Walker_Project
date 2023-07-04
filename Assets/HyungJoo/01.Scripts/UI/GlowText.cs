using UnityEngine;
using System;
using TMPro;
using DG.Tweening;

public class GlowText : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TMP_FontAsset _fontAsset;
    [SerializeField] private GameObject _pp;

    private void Awake() {
        _pp.SetActive(false);    
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            ShowingSequence("Look at Behind");
        }
    }

    [ContextMenu("ShowingSequence")]
    public void ShowingSequence(string text, float scaleValue = 1.5f,float tweenValue = 1.5f,Action Callback = null) {
        SetText(text);
        _pp.SetActive(true);
        _text.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
        Sequence seq = DOTween.Sequence();
        seq.Append(_text.transform.DOScale(Vector3.one,tweenValue).SetEase(Ease.OutQuad));
        seq.AppendCallback(() => {
            Callback?.Invoke();
            _pp.SetActive(false);
        });
    }

    public void SetText(string result) {
        _text.SetText(result);
    }


}
