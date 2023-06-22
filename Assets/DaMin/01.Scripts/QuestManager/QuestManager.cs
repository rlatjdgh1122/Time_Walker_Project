using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct Quests
{
    public string QuestName;
    public UnityEvent OnEnterQuest;
    public UnityEvent OnUpdateQues;
    public UnityEvent OnQuestClear;
    public Vector3 ColiderSize;
    public Vector3 ColiderPos;
    public LayerMask _lay;
    [ColorUsage(true)] public Color ColiderColor;
    //public Quaternion rotation;
}

public struct Colider
{

}

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public Quests[] _questList;
    public Quests _currentQuest { get; private set; }
    public int _currentIndex { get; private set; }

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

        ChangeQuest(_questList[0]);
    }

    private void Update()
    {
        _currentQuest.OnUpdateQues?.Invoke();
    }

    public enum changeType { NextInde, Name }
    [Tooltip("string이 null이면 다음 인덱스")]
    public void ChangeQuestAsColider(string _name = null)
    {
        Collider[] _cols;

        _cols = Physics.OverlapBox(_currentQuest.ColiderPos, _currentQuest.ColiderSize, transform.rotation, _currentQuest._lay);

        if (_cols.Length > 0)
        {
            if (_name == null)
                ChangeQuestNext();
            else
                ChangeQuestAsName(_name);
        }
    }

    public void ChangeQuestAsName(string name)
    {
        for (int i = 0; i < _questList.Length; i++)
        {
            if (_questList[i].QuestName == name)
            {
                ChangeQuest(_questList[i]);
                _currentIndex = i;
                return;
            }
        }
    }

    public void ChangeQuestNext()
    {
        if (_currentIndex >= _questList.Length)
        {
            Debug.LogError("인덱스 범위를 초과함");
            return;
        }

        ChangeQuest(_questList[++_currentIndex]);
    }

    private void ChangeQuest(Quests qu)
    {
        _currentQuest.OnQuestClear?.Invoke();

        _currentQuest = qu;
        _currentQuest.OnEnterQuest?.Invoke();

        Debug.Log($"CurrentQuest : {_currentQuest.QuestName}");
    }

    private void OnDrawGizmos()
    {
        foreach (var item in _questList)
        {
            Gizmos.color = item.ColiderColor;
            Gizmos.DrawCube(item.ColiderPos, item.ColiderSize);
        }
    }
}
