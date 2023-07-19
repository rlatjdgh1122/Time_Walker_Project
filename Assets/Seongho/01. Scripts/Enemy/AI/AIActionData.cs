using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionData : MonoBehaviour
{
    public int Distance = 10;
    public bool TargetSpotted; //���� �߰ߵǾ��°�?
    public Vector3 HitPoint; //���������� ó���� ������ ����ΰ�?
    public Vector3 HitNormal;  //���������� ó���� ������ �븻����
    public Vector3 LastSpotPoint; //���������� �߰ߵ� ������ ����ΰ�?
    public bool IsArrived; //�������� �����ߴ°�?
    public bool IsAttacking; //���� ������ �������ΰ�?

    private List<InnerDistanceDecision> innerDistances = new();
    [field: SerializeField] public bool IsHit { get; set; } //���� �°��ִ�?
    public void Init()
    {
        GetComponentsInChildren<InnerDistanceDecision>(innerDistances);
        innerDistances.ForEach(p => p.Distance = Distance);
        Debug.Log(innerDistances);

        TargetSpotted = false;
        IsArrived = false;
        IsAttacking = false;
        IsHit = false;
    }
}
