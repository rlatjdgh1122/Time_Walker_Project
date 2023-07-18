using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    void Start()
    {
        PostProcessingController.Instance.StopEffect();

        PostProcessingController.Instance.Set_LensDistortion(1, .3f, .9f);
        PostProcessingController.Instance.Set_DigitalGlitchVolume(1, 0, 1);

        InvokeRepeating("Noise", 3, 5);
    }
    private void Noise()
    {
        PostProcessingController.Instance.Set_DigitalGlitchVolume(.2f, 1, 0,
            () => PostProcessingController.Instance.Set_DigitalGlitchVolume(.2f, 0));
    }
    public void MoveScene(string sceneName)
    {
        PostProcessingController.Instance.Set_LensDistortion(1, -.5f);
        PostProcessingController.Instance.Set_DigitalGlitchVolume(1, 1, 0,
            () => SceneManager.LoadScene(sceneName));
    }
}
