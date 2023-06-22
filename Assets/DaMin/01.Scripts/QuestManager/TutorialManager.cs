using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    public Quest[] _quests;
    private int _currentIndex;
    private Quest _previousQuest;
    private Quest _currentQuest = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        foreach (var s in _quests)
        {
            s.gameObject.SetActive(false);
        }

        Init();
    }

    private void Init()
    {
        if (_quests[0] == null)
            return;

        _currentQuest = _quests[0];
        _currentQuest.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (_currentQuest != null)
            _currentQuest.Execute();
    }


    public void ChangeQuest()
    {
        if (_quests.Length <= _currentIndex + 1 || _quests[_currentIndex + 1] == null)
            return;

        if (_currentQuest != null)
        {
            _previousQuest = _currentQuest;
            _currentQuest.Exit();
        }

        ++_currentIndex;
        _currentQuest = _quests[_currentIndex];
        _currentQuest.Enter();

        Debug.Log($"CurrentQuest Index : {_currentIndex}");
    }
}
