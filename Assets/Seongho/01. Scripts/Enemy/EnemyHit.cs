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
        Cut(transform.position + Vector3.up * Random.Range(.85f, 1.15f), transform.up * Random.Range(.85f, 1.15f));
        OnDead?.Invoke();
    }
    public void OnCut_Ver() //���η� �ڸ�
    {
        Cut(transform.position, transform.right);
        OnDead?.Invoke();
    }
}
