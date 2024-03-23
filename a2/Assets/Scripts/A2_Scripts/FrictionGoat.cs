using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    [SerializeField]
    float speed = 3f;
    [SerializeField]
    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Move();
        #endregion
        
    }
    
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _rigidbody.AddForce(transform.forward * speed);
        }
    }
}