using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotation : MonoBehaviour
{
    public float speed = 5f;
    
    private float z = 0;
    
    void Update()
    {
        z += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(90, z, 0);
    }
}
