using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class A2Animal : MonoBehaviour
{
    protected Rigidbody _rb;
    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        _rb.isKinematic = true;
        _rb.freezeRotation = true;
        _rb.detectCollisions = true;
    }

    protected virtual void Move()
    {
        
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TrackEnd>())
        {
            Destroy(this.gameObject);
        }
    }
}
