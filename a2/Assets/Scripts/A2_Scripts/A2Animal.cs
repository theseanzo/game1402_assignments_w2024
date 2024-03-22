using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class A2Animal : MonoBehaviour
{
    protected Rigidbody _rb;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        if (!_rb)
            _rb = gameObject.AddComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _rb.isKinematic = true;
    }

    protected virtual void Move()
    {

    }

}
