using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveState
{
    Idle,
    Move,
    Move_Back,
}
public class EnemyAnimationController : AnimatorHash
{
    public void SetMove(MoveState value)
    {
        if (value == MoveState.Move_Back)
            anim.SetFloat(MOVE_HASH, -1);

        if (value == MoveState.Idle)
            anim.SetFloat(MOVE_HASH, 0);

        if (value == MoveState.Move)
            anim.SetFloat(MOVE_HASH, 1);

    }
    public void SetShooting()
    {
        anim.SetTrigger(SHOOTING_HASH);
    }
    public void SetReloading(bool value)
    {
        if (value == true)
            anim.SetBool(RELOAD_HASH, true);

        if (value == false)
            anim.SetBool(RELOAD_HASH, false);
    }
}
