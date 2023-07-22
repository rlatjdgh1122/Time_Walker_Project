using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest3 : QuestScript
{
    [SerializeField] private int EnemeyCount;
    [SerializeField] private TextMeshProUGUI questTXT;
    private int currentEnemeyCount;
    private void Awake()
    {
        currentEnemeyCount = EnemeyCount;
        FindObjectOfType<QuestManager>().enemyDie += EnemyDie;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EnemyDie()
    {
        currentEnemeyCount--;
        questTXT.text = $"적을 소탕하세요.({EnemeyCount}/{currentEnemeyCount})";

        if (currentEnemeyCount <= 0)
            QuestManager.Instance.ChangeQuestNext();
    }

    public override void OnEnterQuest()
    {
    }

    public override void OnUpdateQues()
    {
    }

    public override void OnQuestClear()
    {
    }
}
