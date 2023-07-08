using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum color
{
    white,
    green,
    yellow,
    red,
    blue,
}
[System.Serializable]
public class TextInfo
{
    public string text;
    public color color;
    public int PontSize;
    public bool isBold;
    public bool isLb;
}

public class ExplainManager : MonoBehaviour
{
    public List<TextInfo> textInfos = new();

    [SerializeField]
    private TMP_Text _tmpText;

    [SerializeField]
    private float _oneCharacterTime = 0.2f;

    private bool _isType = false;  //타이핑중인지 확인
    private string resultText;
    private void Start()
    {
        PostProcessingController.Instance.StopAllCoroutine();

        PostProcessingController.Instance.Set_LensDistortion(1, .3f, .9f);
        PostProcessingController.Instance.Set_DigitalGlitchVolume(1, 0, 1);

        for (int i = 0; i < textInfos.Count; i++)
            Write(textInfos[i]);

        Invoke("StartEffect", 1.2f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
        }
    }
    private void Write(TextInfo textInfo)
    {
        string text = "";
        text += $"<size={textInfo.PontSize}>";
        text += $"<color={textInfo.color.ToString()}>";
        if (textInfo.isBold)
        {
            text += "<b>";
        }
        text += textInfo.text;
        if (textInfo.isBold)
        {
            text += "</b>";
        }
        if (textInfo.isLb)
            text += "\n";
        text += $"</color>";
        text += "</size>";

        resultText += text;
    }
    private void StartEffect()
    {
        _tmpText.SetText(resultText);
        _tmpText.ForceMeshUpdate();
        _tmpText.maxVisibleCharacters = 0;
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        TMP_TextInfo textInfo = _tmpText.textInfo;
        for (int i = 0; i < textInfo.characterCount; ++i)
        {
            yield return StartCoroutine(TypeOneCharCoroutine(textInfo, i));
        }
    }

    private IEnumerator TypeOneCharCoroutine(TMP_TextInfo textInfo, int idx)
    {
        _tmpText.maxVisibleCharacters++;
        _tmpText.ForceMeshUpdate();

        TMP_CharacterInfo charInfo = textInfo.characterInfo[idx];
        if (charInfo.isVisible == false)
        {
            yield return new WaitForSeconds(_oneCharacterTime);
        }
        else
        {
            yield return null;
        }
    }
}
