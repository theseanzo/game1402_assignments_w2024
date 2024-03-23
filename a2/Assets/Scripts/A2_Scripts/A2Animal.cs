using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class A2Animal : MonoBehaviour
{
    public Rigidbody body { get; private set; }
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
        
    // Update is called once per frame

    protected virtual void Move()
    {
        
    }

}
