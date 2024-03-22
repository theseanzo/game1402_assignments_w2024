using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class A2Animal : MonoBehaviour
{
    protected Rigidbody _rigidbody;
    protected bool _isMoving = false;

    void Awake()
    {
        if (_rigidbody == null)
        {
            _rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        _rigidbody.freezeRotation = true;
        _rigidbody.useGravity = false;
    }

    // Update is called once per frame
    protected virtual void Move()
    {
    }
}
