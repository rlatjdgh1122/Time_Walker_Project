using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest<T> where T : class
{
    public abstract void Enter(T manager);
    public abstract void Update(T manager);
    public abstract void Exit(T manager);
}
