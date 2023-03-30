using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float _animDelay = 2f;
    public bool isAttack;
    private AgentInput _agentInput;

    void Start()
    {
        _agentInput = GetComponent<AgentInput>();
        _agentInput.OnFireButtonPress += Attack;
    }

    public void Attack()
    {
        if(!isAttack)
        {
            StartCoroutine(AttackCor());
        }
    }

    IEnumerator AttackCor()
    {
        isAttack = true;
        yield return new WaitForSeconds(_animDelay);
        isAttack = false;
    }
}
