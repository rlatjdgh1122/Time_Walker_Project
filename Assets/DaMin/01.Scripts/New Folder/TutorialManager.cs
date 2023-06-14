using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public Quest<TutorialManager>[] quests;
    private QuestManager<TutorialManager> _tutorialManager;
    [HideInInspector] public int currentQuestIndex;
    private void Awake()
    {
        //_tutorialManager.Setup();
    }

    private void Update()
    {

    }
}
