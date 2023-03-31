using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AgentInput : MonoBehaviour
{
    public event Action OnFireButtonPress;
    public event Action<Vector3> OnMovementKeyPress;

    private void Update()
    {
        InputFireButton();
        InputMovementKeyPress();
        if(Input.GetKeyDown(KeyCode.T))
        {
            PoolableMono obj = PoolManager.Instance.Pop("TestPool");
            obj.transform.position = transform.position;
        }
    }

    private void InputMovementKeyPress()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, 0, v);
        OnMovementKeyPress?.Invoke(direction);
    }


    private void InputFireButton()
    {
        if (Input.GetMouseButton(0))
        { 
            OnFireButtonPress?.Invoke();
        }
    }
    
}
