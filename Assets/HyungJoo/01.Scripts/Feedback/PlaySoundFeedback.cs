using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundFeedback : Feedback{
    private AudioSource _audioSource;

    private AudioClip _clip;

    private void Awake() {
        _audioSource = GetComponent<AudioSource>();
    }
    public override void CompleteFeedback(){
        _audioSource.Stop();
    }

    public override void CreateFeedback(){
        _audioSource.Play();        
    }
}
