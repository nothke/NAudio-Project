using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManySources : MonoBehaviour
{

    public AudioClip[] testClips;

    public float minRate = 1;
    public float maxRate = 1;
    public float radius = 100;

    void OnValidate()
    {
        if (Application.isPlaying)
        {
            StopAllCoroutines();
            StartCoroutine(Co());
        }
    }

    IEnumerator Co()
    {
        while (true)
        {
            float rate = Random.Range(minRate, maxRate);
            if (rate == 0) rate = 0.0001f;

			float time = 1 / rate;
			int num = 1;

			// If time is less than frame time, do multiple
			if (time < Time.deltaTime)
				num = Mathf.RoundToInt( Time.deltaTime / time);

            yield return new WaitForSecondsRealtime(time);

			for (int i = 0; i < num; i++)
			{
				testClips.Play(Random.insideUnitSphere * radius);
			}
        }
    }
}
