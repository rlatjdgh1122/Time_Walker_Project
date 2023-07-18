using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAIState : CommonAIState
{
    public override void OnEnterState()
    {
        _enemyMovement.IsRotate = false;
        _enemyMovement.IsMove = false;
        _enemyAnimationController.SetMove(MOVE_STATE.Idle);
    }

    public override void OnExitState()
    {
        _enemyMovement.IsRotate = true;
        _enemyMovement.IsMove = true;
    }
    public override bool UpdateState()
    {
        return base.UpdateState();
    }
}
