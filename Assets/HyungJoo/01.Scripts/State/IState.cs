using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void OnEnterState();
    public void OnExitState();
    public void UpdateState();
    public void SetUp(Transform agentTransform);
}

public interface IAIState
{
    public void OnEnterState();
    public void OnExitState();
    public bool UpdateState();
    public void SetUp(Transform agentTransform);
}
