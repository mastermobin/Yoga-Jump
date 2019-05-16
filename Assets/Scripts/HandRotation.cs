using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotation : MonoBehaviour
{
    public float speed = 5f;
    public float mult = 1;
    
    private float z;
    private float nextDir = 15;
    
    void Update()
    {
        nextDir -= mult * Time.deltaTime;
        if (nextDir <= 0)
        {
            nextDir = Random.Range(10, 20);
            speed = (Random.Range(0, 1) > 0.5f) ? speed : -speed;
        }
        z += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(90, z, 0);
    }
}
