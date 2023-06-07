using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAIState : CommonAIState
{
    public override void OnEnterState()
    {
        _enemyMovement.StartMove();
        _enemyMovement.StartRotate();
        _enemyAnimationController.SetMove(MoveState.Move);
    }
    public override void OnExitState()
    {
        Debug.Log("ChaseAIState : OnExitState");
        _enemyMovement.StopMove();
        _enemyMovement.StopRotate();
        _enemyAnimationController.SetMove(MoveState.Idle);
    }
    public override bool UpdateState()
    {
        return base.UpdateState();
    }
}
