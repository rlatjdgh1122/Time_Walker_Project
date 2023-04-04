using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolClass
{
    public PoolableMono poolObject;
    public int poolCount = 10;
}


[CreateAssetMenu(menuName = "SO/Pool/PoolingList")]
public class PoolingList : ScriptableObject
{
    public List<PoolClass> poolingList = new List<PoolClass>();
}
