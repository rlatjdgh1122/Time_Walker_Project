using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanelManager : MonoBehaviour
{
    public GameObject SettingPanel;
    private void Start()
    {
        SettingPanel.SetActive(false);
    }
    public void Canel()
    {
        SettingPanel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    /*public void Back()
    {
        int currentSceneNum = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneNum == )
        PostProcessingController.Instance.Set_AnalogVolume(.7f, .35f, 0, () => PostProcessingController.Instance.Set_DigitalGlitchVolume(.7f, 1,
           0, () =>
           {

           }));
    }*/
}
