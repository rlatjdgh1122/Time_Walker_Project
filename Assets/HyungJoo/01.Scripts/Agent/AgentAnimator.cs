using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimator : MonoBehaviour{
    protected Animator _animator;
    protected Transform _agentTransform;
    
    protected virtual void Awake(){
        _animator = transform.GetComponent<Animator>();
        _agentTransform = GetComponentInParent<AgentMovement>().transform;
    }
}                
