using DynamicMeshCutter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHit : PlaneBehaviour
{
    [SerializeField]
    private UnityEvent OnDead;  
    public void OnHit()
    {
        OnDead?.Invoke();
        Cut();
    }
}
