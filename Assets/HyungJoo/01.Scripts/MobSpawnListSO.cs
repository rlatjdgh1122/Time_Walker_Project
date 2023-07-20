using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Mob/SpawnList")]
public class MobSpawnListSO : ScriptableObject
{
    public List<MobSpawnSO> mobSpawnList = new List<MobSpawnSO>();
}