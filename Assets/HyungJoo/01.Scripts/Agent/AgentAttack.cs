using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAttack : MonoBehaviour
{
    private AgentInput _agentInput;

    private void Awake()
    {
        _agentInput = GetComponent<AgentInput>();
        _agentInput.OnFireButtonPress += TryToAttack;
    }


    private void TryToAttack()
    {

    }
}
