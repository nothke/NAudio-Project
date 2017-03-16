using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSourceOnStart : MonoBehaviour {
    
    public AudioClip clip;

	void Start () {
        AudioSource source = NAudio.CreateSource(transform, clip);
        source.Play();
	}
}
