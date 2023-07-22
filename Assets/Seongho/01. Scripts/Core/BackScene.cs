using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScene : MonoBehaviour
{
    public string MoveScene = "IntroScene";
    private bool Press = true;
    private void Update()
    {
        if (Press)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Press = false;
                PostProcessingController.Instance.Set_AnalogVolume(.7f, .35f, 0, () => PostProcessingController.Instance.Set_DigitalGlitchVolume(.7f, 1,
                   0, () =>
                   {
                       SceneManager.LoadScene(MoveScene);
                   }));

            }
        }
       
    }
}
