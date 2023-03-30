using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHP : MonoBehaviour
{
    [SerializeField]
    private int _hp;
    [SerializeField]
    private int _maxHP;

    void Awake()
    {
        _hp = _maxHP;
    }

    public void Damaged(int minus)
    {
        Debug.Log($"Damaged: {_hp}");
        _hp -= minus;
        if(_hp<=0)
        {
            DieProcess();
        }
    }

    private void DieProcess()
    {
        gameObject.SetActive(false);
    }
}
