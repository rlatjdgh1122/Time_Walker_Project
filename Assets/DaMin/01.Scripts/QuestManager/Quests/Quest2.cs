using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest2 : QuestScript
{
    public override void OnEnterQuest()
    {

    }

    public override void OnQuestClear()
    {

    }

    public override void OnUpdateQues()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            QuestManager.Instance.ChangeQuestNext();
    }

}
