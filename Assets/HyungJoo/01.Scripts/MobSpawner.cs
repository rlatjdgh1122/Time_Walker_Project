using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]public class MobSpawner : MonoBehaviour {
    private static MobSpawner _instance;
    public static MobSpawner Instance => _instance;
    [SerializeField]
    private MobSpawnListSO _mobSpawnListSO;
    private void Awake() {
        if(_instance == null) {
            _instance = this;
        }
    }

    public void SpawnMob(int idx)
    {
        var m = _mobSpawnListSO.mobSpawnList[idx];
        foreach(var enemy in m.mobSpawnList)
        {
            for(int i =0 ; i < enemy.cnt; i++)
            {
                Debug.Log(PoolManager.Instance);
                PoolableMono e = PoolManager.Instance.Pop(enemy.enemy.gameObject.name) as PoolableMono;
                e.transform.position = m.spawnPos;
            }
        }
    }
}