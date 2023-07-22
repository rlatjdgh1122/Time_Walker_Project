using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Mob
{
    public PoolableMono enemy;
    public int cnt;
    public Vector3 spawnPos;
}


[CreateAssetMenu(menuName ="SO/Mob/Spawn")]
public class MobSpawnSO : ScriptableObject
{
    public List<Mob> mobSpawnList = new List<Mob>();
}