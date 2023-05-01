using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentAttack : MonoBehaviour{
    protected AgentMovement _movement;
    protected PlayerActionData _actionData;

    public UnityEvent OnAnimationEnd;

    protected virtual void Awake() {
        _movement = GetComponent<AgentMovement>();
        _actionData = transform.Find("ActionData").GetComponent<PlayerActionData>();
    }

    public void AnimationEnd(){
        OnAnimationEnd?.Invoke();
    }
}
