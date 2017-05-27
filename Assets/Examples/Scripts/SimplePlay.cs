/// Plays a random clip from array at random pitch on mouse click

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlay : MonoBehaviour
{

    public AudioClip[] clips;
    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            clips.Play(Vector3.zero, pitch: Random.Range(minPitch, maxPitch));
    }
}
