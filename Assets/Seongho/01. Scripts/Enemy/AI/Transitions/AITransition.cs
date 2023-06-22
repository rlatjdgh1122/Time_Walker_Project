using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    [SerializeField]
    private List<AIDecision> _decisions;

    [SerializeField]
    private CommonAIState _nextState;
    public CommonAIState NextState => _nextState;

    public void SetUp(Transform parentRoot)
    {
        _decisions = new List<AIDecision>();
        GetComponents<AIDecision>(_decisions); //��� ����� ��������
        _decisions.ForEach(d => d.SetUp(parentRoot)); //������ �ִ� ��� ������� �¾�
    }

    public bool CheckDecisions()
    {
        bool result = false;

        foreach (AIDecision d in _decisions)
        {
            result = d.MakeDecision();
            if (d.IsReverse)
                result = !result;
            if (result == false)
                break;
        }
        return result;
    }
}
