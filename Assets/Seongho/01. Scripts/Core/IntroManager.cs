using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    void Start()
    {
        PostProcessingController.Instance.StopAllCoroutine();

        PostProcessingController.Instance.Set_LensDistortion(1, .3f, .9f);
        PostProcessingController.Instance.Set_DigitalGlitchVolume(1, 0, 1);
    }
    public void MoveScene(string sceneName)
    {
        PostProcessingController.Instance.Set_LensDistortion(1, -.5f);
        PostProcessingController.Instance.Set_DigitalGlitchVolume(1, 1, 0,
            () => SceneManager.LoadScene(sceneName));
    }
}
