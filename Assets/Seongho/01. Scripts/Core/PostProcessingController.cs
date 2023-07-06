using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class PostProcessingController : MonoBehaviour
{

    public static PostProcessingController Instance;
    private LensDistortion len;
    private Volume volume;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(Instance);

        // 포스트 프로세싱 프로필(Post-Processing Profile) 가져오기
        volume = GetComponent<Volume>();

        // 렌즈 왜곡 효과 가져오기
        volume.profile.TryGet(out len);
    }
    public void Set_LensDistortion(float time, float init_intensity, float intensity)
    {
        len.intensity.value = init_intensity;
        StartCoroutine(lenDistortion(time, intensity));
    }
    private IEnumerator lenDistortion(float time, float intensity)
    {
        float elapsedTime = 0;
        float startIntensity = len.intensity.value;

        while (elapsedTime < time)
        {
            // 보간하여 intensity 값 조절
            len.intensity.value = Mathf.Lerp(startIntensity, intensity, elapsedTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 최종 intensity 값 설정
        len.intensity.value = intensity;
    }
}
