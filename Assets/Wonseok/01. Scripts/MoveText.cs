using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MoveText : MonoBehaviour
{
    [SerializeField]
    private RectTransform _tutorialTextPos;
    [SerializeField]
    private TextMeshProUGUI _tutorialText;

    [SerializeField]
    private RectTransform _tutorialTextPos02;
    [SerializeField]
    private TextMeshProUGUI _tutorialText02;

    [SerializeField]
    private float showTextSpeed = 1.25f;
    [SerializeField]
    private float waitSec = 1f;
    [SerializeField]
    private float nextWaitSec = 1f;
    [SerializeField]
    private float readySec = 5f;

    [SerializeField]
    string[] texts = { "W A S D 로 움직이세요", "좌클릭을 눌러 공격하세요" };

    public int textNum = 0;

    private void Awake()
    {
        TutorialTexts();
        ReadyTexts();
    }

    public void TutorialTexts()
    {
        if (textNum <= 2)
        {
            Sequence seq1 = DOTween.Sequence();
            seq1.AppendInterval(nextWaitSec);
            seq1.Append(_tutorialTextPos.DOAnchorPos(
                new Vector2(0, _tutorialTextPos.anchoredPosition.y), showTextSpeed).SetEase(Ease.InOutBack));
            seq1.AppendInterval(waitSec);
            seq1.Append(_tutorialTextPos.DOAnchorPos(
                new Vector2(-2000, _tutorialTextPos.anchoredPosition.y), showTextSpeed).SetEase(Ease.InOutBack));
            seq1.OnComplete(() =>
            {
                textNum++;
                _tutorialText.text = texts[textNum];
                _tutorialTextPos.anchoredPosition = new Vector2(1500, _tutorialTextPos.anchoredPosition.y);
                seq1.Restart();
            });
        }
    }

    public void ReadyTexts()
    {
        Sequence seq2 = DOTween.Sequence();
        seq2.AppendInterval(readySec);
        seq2.Append(_tutorialTextPos02.DOAnchorPos(
            new Vector2(_tutorialTextPos02.anchoredPosition.x, 0), showTextSpeed).SetEase(Ease.InOutSine));
        seq2.AppendInterval(waitSec);
        seq2.Append(_tutorialTextPos02.DOAnchorPos(
            new Vector2(_tutorialTextPos02.anchoredPosition.x, -1000), showTextSpeed).SetEase(Ease.OutBack));
    }
}
