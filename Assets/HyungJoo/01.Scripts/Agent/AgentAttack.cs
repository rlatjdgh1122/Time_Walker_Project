using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentAttack : MonoBehaviour
{
    public UnityEvent OnAnimationEnd;
    public bool isAttacking;
    public void AnimationEnd()
    {
        OnAnimationEnd?.Invoke();
    }
}
