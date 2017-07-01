using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Benchmark_ConcurrentLoops : MonoBehaviour
{

    public int numberOfSources = 100;
    public float range = 50;
    public AudioClip[] clips;

    void Start()
    {
        CreateSources();//
    }

    void CreateSources()
    {
        for (int i = 0; i < numberOfSources; i++)
        {
            AudioClip randomClip = clips[Random.Range(0, clips.Length)];
            var source = NAudio.CreateSource(null, randomClip);
            source.transform.position = Random.insideUnitSphere * range;
            source.PlayRandomTime();
        }
    }
}
