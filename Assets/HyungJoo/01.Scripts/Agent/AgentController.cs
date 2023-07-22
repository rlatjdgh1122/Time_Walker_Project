using System;
using System.Collections.Generic;
using UnityEngine;
using static Core.Define;

public class AgentController : MonoBehaviour
{
    private Dictionary<StateType, IState> _stateDictionary;
    private IState _currentState;
    private AgentInput _agentInput;
    private void Awake(){
        _stateDictionary = new Dictionary<StateType, IState>();
        Transform stateTransform = transform.Find("States");
        foreach(StateType state in Enum.GetValues(typeof(StateType)))
        {
            IState stateScript = stateTransform.GetComponent($"{state}State") as IState;
            if(stateScript == null)
            {
                Debug.LogError($"There is no Script {state}");
            }
            stateScript.SetUp(transform);
            _stateDictionary.Add(state,stateScript);
        }
        _agentInput = GetComponent<AgentInput>();
        _agentInput.OnEscKeyPress += UIManager.Instance.ShowPanel;
        PostProcessingController.Instance.StopEffect();
    }
    
    private void Start(){
        ChangeState(StateType.Normal);

    }

    private void Update(){
        //Debug.Log(_currentState);
        _currentState.UpdateState();
    }

    public void ChangeState(StateType state){
        _currentState?.OnExitState();
        _currentState = _stateDictionary[state];
        _currentState?.OnEnterState();
    }
}
