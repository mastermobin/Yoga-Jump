using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotation : MonoBehaviour
{
    public float range = 0.06f;
    public float time = 5;
    private Vector3 dir = Vector3.zero;
    private float t = -1000;

    void Update()
    {
        if (Time.time - t > time)
        {
            dir = new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
            t = Time.time;
        }
        transform.Rotate(dir);
        
    }
}
