using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AgentInput : MonoBehaviour
{
    public event Action OnFireButtonPress;

    void Update()
    {
        GetFireButtonInput();
    }

    private void GetFireButtonInput()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            OnFireButtonPress?.Invoke();
        }
    }
}
