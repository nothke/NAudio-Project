using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSourceOnStart : MonoBehaviour {
    
    AudioClip clip;

	void Start () {
        NAudio.CreateSource(transform, clip);
	}
}
