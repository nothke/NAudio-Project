using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInCircle : MonoBehaviour
{

    public float speed = 1;

    float startDistance;

    void Start()
    {
        startDistance = transform.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time * speed), 0, Mathf.Cos(Time.time * speed)) * startDistance;
    }
}
