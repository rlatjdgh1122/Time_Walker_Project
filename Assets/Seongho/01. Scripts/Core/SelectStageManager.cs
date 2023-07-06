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
    HARD
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
        PostProcessingController.Instance.Set_LensDistortion(1, .9f, .3f);

        for (int i = 0; i < items.Count; i++)
        {
            Setting(items[i], setStages[i].StageName, setStages[i].DiffcultyName.ToString(), setStages[i].Explain);
        }
    }

    public void MoveScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    private void Setting(GameObject item, string stageName, string diffcultyName, string explain)
    {
        TextMeshProUGUI stage = item.transform.Find("Stage").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI diffculty = item.transform.Find(" Difficulty").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI exp = item.transform.Find("Explain").GetComponent<TextMeshProUGUI>();

        stage.text = stageName;
        diffculty.text = diffcultyName;
        exp.text = explain;
    }
}
