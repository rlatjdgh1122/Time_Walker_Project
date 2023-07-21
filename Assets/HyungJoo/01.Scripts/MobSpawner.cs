using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Mob
{
    public PoolableMono enemy;
}
public class MobSpawner : MonoBehaviour {
    private static MobSpawner _instance;
    public static MobSpawner Instance => _instance;


    private void Awake() {
        if(_instance == null) {
            _instance = this;
        }


    }

    public void SpawnMob()
    {

    }
}