﻿    
using UnityEngine;

public class CameraNoise : MonoBehaviour
{
    public float range = 0.06f;
    public float time = 5;
    private float x, y, z;
    public Transform target;
    
    private Vector3 dir;
    private float t = -1000;
    
    void Update()
    {
        if (Time.time - t > time)
        {
            if (transform.position.x < -6) x = Random.Range(0, range); 
            else if (transform.position.x > 6) x = Random.Range(-range, 0);
            else x = Random.Range(-range, range);
            
            if (transform.position.y < 9) y = Random.Range(0, range); 
            else if (transform.position.y > 14) y = Random.Range(-range, 0);
            else y = Random.Range(-range, range);
            
            if (transform.position.z < -28) z = Random.Range(0, range); 
            else if (transform.position.z > -26) z = Random.Range(-range, 0);
            else z = Random.Range(-range, range);
            
            dir = new Vector3(x, y, z);
            t = Time.time;
        }
        
        transform.Translate(dir);
        transform.LookAt(target);
        
    }
}