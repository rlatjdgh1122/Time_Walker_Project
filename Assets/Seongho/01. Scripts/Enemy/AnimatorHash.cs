using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimatorHash : MonoBehaviour
{
    protected Animator _anim;
    protected int MOVE_HASH = Animator.StringToHash("Move");
    protected int SHOOTING_HASH = Animator.StringToHash("Shooting");
    protected int RELOAD_HASH = Animator.StringToHash("Reloading");

    protected virtual void Awake()
    {
        _anim = GetComponent<Animator>();
    }


}
