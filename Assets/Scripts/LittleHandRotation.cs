using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleHandRotation : MonoBehaviour
{
    public float speed = 5f;
    
    private float z;
    
    void Update()
    {
        z += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(-90, z, 0);
    }
}
