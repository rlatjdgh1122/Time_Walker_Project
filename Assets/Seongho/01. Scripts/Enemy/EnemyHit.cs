using DynamicMeshCutter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHit : PlaneBehaviour
{
    [SerializeField]
    private UnityEvent OnDead;  

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            Debug.Log("eqwr");
            OnHit();
        }
    }
    public void OnHit()
    {
        //Cut();
        OnDead?.Invoke();
    }
}
