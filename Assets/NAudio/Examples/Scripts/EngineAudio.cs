using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineAudio : MonoBehaviour
{
    public AudioClip clip;

    public AnimationCurve volumeCurve;
    public AnimationCurve pitchCurve;

    float value;

    AudioSource source;

    void Start()
    {
        source = NAudio.CreateSource(transform, clip);
        source.Play();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
            value += Time.deltaTime;
        else
            value -= Time.deltaTime;

        value = Mathf.Clamp01(value);

        source.volume = volumeCurve.Evaluate(value);
        source.pitch = pitchCurve.Evaluate(value);
    }
}
