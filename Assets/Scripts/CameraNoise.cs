using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNoise : MonoBehaviour
{
    public float range = 0.06f;
    public float time = 5;
    public Transform target;

    private Transform baseTrans;
    private Vector3 dir = Vector3.zero;
    private float t = -1000;

    private void Start()
    {
        baseTrans = transform;
    }

    void Update()
    {
        if (Time.time - t > time)
        {
            dir = new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
            if((dir * (time / Time.deltaTime)) + transform.position)
            t = Time.time;
        }
        transform.Translate(dir);
        transform.LookAt(target);
        
    }
}
