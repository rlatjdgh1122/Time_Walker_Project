using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticle : PoolableMono{
    private ParticleSystem _particleSystem;

    public override void Init(){
        _particleSystem.Stop();
        _particleSystem.Play();
    }

    private void Awake() {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void SpawnParticle(Vector3 pos){
        transform.position = pos;
        Invoke("DisableParticle",0.5f);
    }

    public void DisableParticle(){
        PoolManager.Instance.Push(this);
    }


}
