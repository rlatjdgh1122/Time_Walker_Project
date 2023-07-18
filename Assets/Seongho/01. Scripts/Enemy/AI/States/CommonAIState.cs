using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommonAIState : MonoBehaviour, IAIState
{
    protected List<AITransition> _transitions;

    protected EnemyController _enemyController;
    protected EnemyMovement _enemyMovement;
    protected AIActionData _aiActionData;
    protected EnemyAnimationController _enemyAnimationController;
    protected EnemyWeaponController _enemyWeaponController;

    protected IWeaponable currentWeapon => _enemyController.currentWeapon;
    public abstract void OnEnterState();
    public abstract void OnExitState();

    public virtual void SetUp(Transform agentRoot)
    {
        _enemyController = agentRoot.GetComponent<EnemyController>();
        _enemyMovement = agentRoot.GetComponent<EnemyMovement>();
        _enemyAnimationController = agentRoot.GetComponent<EnemyAnimationController>();
        _enemyWeaponController = agentRoot.GetComponent<EnemyWeaponController>();

        _aiActionData = agentRoot.Find("AI").GetComponent<AIActionData>();

        _transitions = new List<AITransition>();
        GetComponentsInChildren<AITransition>(_transitions);

        _transitions.ForEach(t => t.SetUp(agentRoot)); //���⼭���� �¾��� �����Ѵ�.
    }

    public virtual bool UpdateState()
    {
        foreach (AITransition t in _transitions)
        {
            if (t.CheckDecisions())
            {
                _enemyController.ChangeState(t.NextState);
                return true;
            }
        }

        foreach (AITransition t in _enemyController.AnyTransitions)
        {
            if (t.CheckDecisions())
            {
                _enemyController.ChangeState(t.NextState);
                return true;
            }
        }
        return false;
    }
}
