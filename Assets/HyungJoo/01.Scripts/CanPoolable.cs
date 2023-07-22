using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPoolable : PoolableMono
{
    public override void Init()
    {
        Debug.Log("Init");
        gameObject.SetActive(true);
    }
}