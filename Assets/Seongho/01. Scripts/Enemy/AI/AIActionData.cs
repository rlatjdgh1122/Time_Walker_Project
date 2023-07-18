using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionData : MonoBehaviour
{
    public int Distance = 10;
    public bool TargetSpotted; //적이 발견되었는가?
    public Vector3 HitPoint; //마지막으로 처맞은 지점은 어디인가?
    public Vector3 HitNormal;  //마지막으러 처맞은 지점의 노말벡터
    public Vector3 LastSpotPoint; //마지막으로 발견된 지점은 어디인가?
    public bool IsArrived; //목적지에 도착했는가?
    public bool IsAttacking; //현재 공격이 진행중인가?

    private List<InnerDistanceDecision> innerDistances = new();
    [field: SerializeField] public bool IsHit { get; set; } //현재 맞고있니?
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
