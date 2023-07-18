using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MobInfo {



}
public class MobSpawner : MonoBehaviour {
    private static MobSpawner _instance;
    public static MobSpawner Instance => _instance;

    public List<PoolableMono> mobList = new List<PoolableMono>();
    private void Awake() {
        if(_instance == null) {
            _instance = this;
        }


    }




}