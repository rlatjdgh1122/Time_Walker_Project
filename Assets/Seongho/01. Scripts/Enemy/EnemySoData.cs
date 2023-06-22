using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemySoData")]
public class EnemySOData : ScriptableObject
{
    public float Speed;
    public float RotateSpeed;
    public float PlayerDistance;
    public float AttackDelay;
}
