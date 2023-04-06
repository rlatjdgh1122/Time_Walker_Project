using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PoolingList _poolingList;
    public static GameManager Instance;
    [SerializeField]
    private GameObject Target;
    public GameObject target => Target;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this);
        DontDestroyOnLoad(this);
        CreatePool();
    }


    public void CreatePool()
    {
        PoolManager manager = new PoolManager(this.transform);
        TimeController controller = transform.AddComponent<TimeController>();
        
        Debug.Log(manager);
        foreach(PoolClass p in _poolingList.poolingList)
        {
            manager.CreatePool(p.poolObject, p.poolCount);
        }
    }
}
