using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Define;
public class ParticlePlayer : PoolableMono{
    private ParticleSystem _particle;
    private void Awake() {
        _particle = GetComponent<ParticleSystem>();
    }

    public override void Init(){
        Invoke("PoolPush", 2f);
    }
    public void PoolPush() {
        PoolManager.Instance.Push(this);
    }
}