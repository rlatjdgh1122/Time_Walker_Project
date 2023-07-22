using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum DIFFCULTY
{
    EASY,
    NORMAL,
    HARD,
    TUTORIAL
}

[System.Serializable]
public class SetStage
{
    public string StageName;
    public DIFFCULTY DiffcultyName;
    public string Explain;
}
public class SelectStageManager : MonoBehaviour
{
    public List<SetStage> setStages = new();
    public List<GameObject> items = new();
    private void Start()
    {
        PostProcessingController.Instance.StopEffect();

        PostProcessingController.Instance.Set_LensDistortion(1, .3f, .9f);
        PostProcessingController.Instance.Set_DigitalGlitchVolume(1, 0, 1);

        for (int i = 0; i < items.Count; i++)
        {
            Setting(items[i], setStages[i].StageName, setStages[i].DiffcultyName.ToString(), setStages[i].Explain);
        }
    }

    public void MoveScene(string sceneName)
    {
        PostProcessingController.Instance.Set_Bloom(1.2f, 25, 3);

        PostProcessingController.Instance.Set_AnalogVolume(.9f, .7f, 0, () => PostProcessingController.Instance.Set_DigitalGlitchVolume(.3f, 1,
           0, () =>
           {
               SceneManager.LoadScene(sceneName);
               PostProcessingController.Instance.Set_Bloom();
               PostProcessingController.Instance.Set_AnalogVolume();
               PostProcessingController.Instance.Set_DigitalGlitchVolume();
               PostProcessingController.Instance.Set_LensDistortion();
           })
        );
    }
    private void Setting(GameObject item, string stageName, string diffcultyName, string explain)
    {
        TextMeshProUGUI stage = item.transform.Find("Stage").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI diffculty = item.transform.Find(" Difficulty").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI exp = item.transform.Find("Explain").GetComponent<TextMeshProUGUI>();


        stage.text = stageName;
        if (diffcultyName == DIFFCULTY.EASY.ToString())
        {
            diffculty.text = "<color=yellow>" + diffcultyName + "</color>";
        }
        else if (diffcultyName == DIFFCULTY.NORMAL.ToString())
        {
            diffculty.text = "<color=orange>" + diffcultyName + "</color>";
        }
        else if (diffcultyName == DIFFCULTY.HARD.ToString())
        {
            diffculty.text = "<color=red>" + diffcultyName + "</color>";
        }
        else
            diffculty.text = "<color=blue>" + diffcultyName + "</color>";
        exp.text = explain;
    }
}
