using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator anim;
    private WeaponDataSO weaponDataSO;
    protected virtual void Awake()
    {
        weaponDataSO = GetComponent<EnemyController>().weaponDataSO;
        anim = GetComponent<Animator>();

        anim.runtimeAnimatorController = weaponDataSO.animatiorController;
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
