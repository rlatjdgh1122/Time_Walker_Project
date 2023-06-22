using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();

    public virtual void QuestClear()
    {
        TutorialManager.Instance.ChangeQuest();
    }
}
