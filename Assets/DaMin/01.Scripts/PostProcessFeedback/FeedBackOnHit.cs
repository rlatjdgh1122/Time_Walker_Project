using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class FeedBackOnHit : Feedback
{
    [SerializeField] private Volume _volume;
    private VolumeProfile volumeProfile;
    private Bloom _bloom;
    private AmbientOcclusion _ao;
    private Vignette _vig;

    private void Awake()
    {
        _volume = GetComponent<Volume>();

        if (_volume.profile.TryGet<Bloom>(out _bloom))
        {

        }
    }

    void Update()
    {
        if (_vig.smoothness.value > 0.25f)
            _vig.smoothness.value -= Time.deltaTime * 2;

        if (_vig.smoothness.value < 0.25f)
            _vig.smoothness.value = 0.25f;
        //_vig.intensity.value = Mathf.Lerp(1, 0.25f, Time.deltaTime * 2);
    }

    public override void CompleteFeedback()
    {
        _vig.smoothness.value = 0.25f;
    }

    public override void CreateFeedback()
    {
        _vig.smoothness.value = 1;
        //_vig.smoothness.value = Mathf.Lerp(1, 0.25f, Time.deltaTime * 2);
    }
}

