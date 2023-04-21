using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator anim;
    private EnemySoData enemySoData;

    private readonly int HashMove = Animator.StringToHash("Move");
    private readonly int HashShootting = Animator.StringToHash("Shooting");
    protected virtual void Awake()
    {
        enemySoData = GetComponent<EnemyController>().EnemySoData;
        anim = GetComponent<Animator>();

        anim.runtimeAnimatorController = enemySoData.weaponData.animatiorController;
    }
    public void SetAnimatorController(AnimatorOverrideController animator)
    {
        anim.runtimeAnimatorController = animator;
    }
    public void MoveAnim(bool moving)
    {
        if (moving)
            anim.SetFloat(HashMove, 1);
        else
            anim.SetFloat(HashMove, 0);
    }
    public void ShootAnim()
    {
        anim.SetTrigger(HashShootting);
    }
}
