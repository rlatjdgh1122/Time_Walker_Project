using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimator : MonoBehaviour
{
    protected Animator _animator;

    protected virtual void Awake(){
        _animator = GetComponent<Animator>();
    }

}
