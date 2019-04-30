using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Jump");
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0f, 0f, 0.05f);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0f, 0f, -0.05f);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.05f, 0f, 0f);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.05f, 0f, 0f);
        }
    }
    
    void OnCollisionEnter (Collision col)
    {
        Destroy(this);
        Debug.Log("hey");
    }
}
