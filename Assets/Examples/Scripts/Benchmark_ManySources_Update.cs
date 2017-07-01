using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Benchmark_ManySources_Update : MonoBehaviour
{

    public AudioClip[] clips;
    public int ratePerFrame = 1;
    public float range = 10;

    public bool usePerf;

    void Update()
    {
        for (int i = 0; i < ratePerFrame; i++)
        {
            if (!usePerf)
                clips.Play(Random.insideUnitSphere * range);
        }
    }
}
