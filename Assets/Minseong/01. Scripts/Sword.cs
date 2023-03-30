using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator animator;
    Player player;

    void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponentInParent<Player>();
    }

    public void Attack()
    {
        if (!player.isAttacking)
        {
            animator.SetTrigger("attack");
            player.isAttacking = true;
        }
    }

    public void AttackEnd()
    {
        player.isAttacking = false;
    }
}
