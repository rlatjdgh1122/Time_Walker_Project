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

        // ����Ʈ ���μ��� ������(Post-Processing Profile) ��������
        volume = GetComponent<Volume>();

        // ���� �ְ� ȿ�� ��������
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
            // �����Ͽ� intensity �� ����
            len.intensity.value = Mathf.Lerp(startIntensity, intensity, elapsedTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ���� intensity �� ����
        len.intensity.value = intensity;
    }
}
