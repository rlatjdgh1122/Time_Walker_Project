using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator anim;
    private EnemySoData enemySoData;
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
    public void MoveAnim(float speed)
    {
        anim.SetFloat("Move", speed);
    }
    public void ShootAnim()
    {
        anim.SetTrigger("Shooting");
    }
}
