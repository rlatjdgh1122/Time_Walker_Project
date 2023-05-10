using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSlash : MonoBehaviour{
    public List<ParticleSystem> particles = new List<ParticleSystem>();

    private void Awake() {
        particles = GetComponentsInChildren<ParticleSystem>().ToList();
    }

    [ContextMenu("Play")]
    public void Play(){
        particles.ForEach(p => p.Play());
    }
}