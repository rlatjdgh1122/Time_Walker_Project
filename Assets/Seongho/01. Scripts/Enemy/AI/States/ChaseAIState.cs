using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAIState : CommonAIState
{
    public override void OnEnterState()
    {
        _enemyAnimationController.SetMove(MOVE_STATE.Move);
        _enemyMovement.SetSpeed(_enemyController.enemySOData.Speed);
    }
    public override void OnExitState()
    {
    }
    public override bool UpdateState()
    {
        return base.UpdateState();
    }
}
