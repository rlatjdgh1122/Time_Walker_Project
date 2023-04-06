using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemySoData")]
public class EnemySoData : ScriptableObject
{
    public float attackCoolTime;
    public float shootDistance;
    public float speed;
    public float attackRadius => shootDistance;

}
