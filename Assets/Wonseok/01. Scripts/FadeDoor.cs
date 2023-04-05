using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeDoor : MonoBehaviour
{
    [SerializeField]
    private Renderer[] doorsMat;
    [SerializeField]
    private GameObject[] doorsObj;

    [SerializeField]
    private Color startColor, endColor;
    [SerializeField]
    private float fadeSpeed;

    int num = 0;

    private void Awake()
    {
        num = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FadeDoorOpen();
        }
    }

    public void FadeDoorOpen()
    {
        if (num < doorsMat.Length && num < doorsObj.Length)
        {
            doorsMat[num].material.DOColor(endColor, fadeSpeed).OnComplete(() =>
            {
                doorsMat[num].material.color = startColor;
                doorsObj[num].SetActive(false);
                num++;
            });
        }
    }
}
