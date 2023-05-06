using DynamicMeshCutter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHit : PlaneBehaviour
{
    [SerializeField]
    private UnityEvent OnDead;
    public void OnCut_Hor() //���η� �ڸ�
    {
        Cut(transform.position + Vector3.up, transform.up);
        OnDead?.Invoke();
    }
    public void OnCut_Ver() //���η� �ڸ�
    {
        Cut(transform.position, transform.right);
        OnDead?.Invoke();
    }
}
