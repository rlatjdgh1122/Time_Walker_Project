using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : PoolableMono
{
    public override void Init()
    {
        this.transform.position = Vector3.zero;
    }
}
