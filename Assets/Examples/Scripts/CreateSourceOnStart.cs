/// Creates source on start (and plays it) as a child of the transform it is attached to

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSourceOnStart : MonoBehaviour {
    
    public AudioClip clip;

	void Start () {
        NAudio.CreateSource(transform, clip).Play();
	}
}
