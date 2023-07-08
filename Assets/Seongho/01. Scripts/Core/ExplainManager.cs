using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public class WriteText
{
    public string text;
    public Color textColor = Color.white;
    public bool isShake = false;
    public bool isStrong = false;
}
[System.Serializable]
public class Write
{
    public List<WriteText> texts = new List<WriteText>();
}
public class ExplainManager : MonoBehaviour
{
    public List<Write> pages = new List<Write>();
    public TextMeshProUGUI _text;
    private void Start()
    {
        ReadingStart();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) StopAllCoroutines();
    }
    public void ReadingStart()
    {
        StartCoroutine(Reading());
    }
    private IEnumerator Reading()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            yield return StartCoroutine((ReadPage(pages[i])));
        }
    }
    private IEnumerator ReadPage(Write write)
    {
        for (int i = 0; i < write.texts.Count; i++)
        {
            yield return StartCoroutine((PrintText(write.texts[i].text)));
        }
    }
    private IEnumerator PrintText(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            _text.text += text[i];
            yield return new WaitForSeconds(.1f);
        }

    }
}
