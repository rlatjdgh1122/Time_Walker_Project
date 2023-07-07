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
    [SerializeField] private float _colorChangeSpeed;

    [SerializeField] private Image _line;

    private bool IsPress = true;
    //지지직 거리고 타이워커 이렇게
    private void Start()
    {
        IsPress = true;
        StartNoise();

        InvokeRepeating("Noise", 3, 3);
    }
    float timer = 0;
    private void Update()
    {
       /* timer += (Time.deltaTime * _colorChangeSpeed);
        _line.color = Color.HSVToRGB(timer % 360, 1, 1);
*/
        if (IsPress)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IsPress = false;

                PostProcessingController.Instance.StopAllCoroutines();

                PostProcessingController.Instance.Set_LensDistortion(1f, -.5f, 0,
             () => PostProcessingController.Instance.Set_DigitalGlitchVolume(.3f, 1,
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
