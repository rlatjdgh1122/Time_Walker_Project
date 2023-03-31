using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommonState : MonoBehaviour, IState
{
    protected AgentInput _agentInput;
    protected AgentAnimator _agentAnimator;
    protected AgentController _agentController;
    protected AgentMovement _agentMovement;

    public abstract void OnEnterState();
    public abstract void OnExitState();
    public abstract void UpdateState();


    public virtual void SetUp(Transform agentTransform)
    {
        _agentAnimator = agentTransform.Find("Weapon").GetComponent<AgentAnimator>();
        _agentMovement = agentTransform.GetComponent<AgentMovement>();
        _agentController = agentTransform.GetComponent<AgentController>();
        _agentInput = agentTransform.GetComponent<AgentInput>();
    }


}
