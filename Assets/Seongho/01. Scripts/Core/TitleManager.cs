using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _texts;
    [SerializeField] private float _showSpeed;

    private bool IsPress = true;
    private void Start()
    {
        IsPress = true;
        StartNoise();

        InvokeRepeating("Noise", 3, 5);
    }
    private void Update()
    {
        if (IsPress)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IsPress = false;
                CancelInvoke("Noise");

                PostProcessingController.Instance.StopEffect();

                PostProcessingController.Instance.Set_AnalogVolume(.7f, .35f, 0, () => PostProcessingController.Instance.Set_DigitalGlitchVolume(.7f, 1,
            0, () => SceneManager.LoadScene("IntroScene")));
            }
        }
    }
    private void ShowTexts()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_texts[0].rectTransform.DOAnchorPos(new Vector3(-285, -100, 0), _showSpeed).SetEase(Ease.OutElastic));
        seq.Join(_texts[1].rectTransform.DOAnchorPos(new Vector3(150, -270, 0), _showSpeed).SetEase(Ease.OutElastic));
        seq.AppendInterval(0.1f);
        seq.Join(_texts[2].DOFade(1, 1f));


    }
    private void StartNoise()
    {
        PostProcessingController.Instance.Set_DigitalGlitchVolume(.4f, 1, 0,
            () => PostProcessingController.Instance.Set_DigitalGlitchVolume(.4f, 0,
           1, () => ShowTexts()));
    }
    private void Noise()
    {
        PostProcessingController.Instance.Set_DigitalGlitchVolume(.2f, 1, 0,
            () => PostProcessingController.Instance.Set_DigitalGlitchVolume(.2f, 0));
    }
}
