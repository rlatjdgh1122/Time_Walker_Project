using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using URPGlitch.Runtime.DigitalGlitch;

public class PostProcessingController : MonoBehaviour
{

    public static PostProcessingController Instance;
    private LensDistortion len;
    private DigitalGlitchVolume dig;
    private Volume volume;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(Instance);

        DontDestroyOnLoad(Instance);

        volume = GetComponent<Volume>();

        volume.profile.TryGet(out len);
        volume.profile.TryGet(out dig);
    }
    public void StopAllCoroutine()
    {
        StopAllCoroutines();
    }
    public void Set_LensDistortion(float time = 0, float intensity = 0, float init_intensity = 100, Action action = null) //볼록
    {
        if (init_intensity == 100) init_intensity = len.intensity.value;

        len.intensity.value = init_intensity;
        StartCoroutine(lenDistortion(time, intensity, init_intensity, action));
    }
    public void Set_DigitalGlitchVolume(float time = 0, float intensity = 0, float init_intensity = 100, Action action = null) //볼록
    {
        if (init_intensity == 100) init_intensity = dig.intensity.value;

        dig.intensity.value = init_intensity;
        StartCoroutine(DigitalGlitchVolume(time, intensity, init_intensity, action));
    }
    private IEnumerator DigitalGlitchVolume(float time, float intensity, float init_intensity, Action action)
    {
        float elapsedTime = 0;
        float startIntensity = init_intensity;

        while (elapsedTime < time)
        {
            dig.intensity.value = Mathf.Lerp(startIntensity, intensity, elapsedTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        dig.intensity.value = intensity;

        if (action != null) action();
    }
    private IEnumerator lenDistortion(float time, float intensity, float init_intensity, Action action)
    {
        float elapsedTime = 0;
        float startIntensity = init_intensity;

        while (elapsedTime < time)
        {
            len.intensity.value = Mathf.Lerp(startIntensity, intensity, elapsedTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        len.intensity.value = intensity;

        if (action != null) action();
    }
}
