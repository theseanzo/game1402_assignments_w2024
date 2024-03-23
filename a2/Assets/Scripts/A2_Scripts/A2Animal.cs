using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class A2Animal : MonoBehaviour
{
    protected bool _shouldMove = false;
    protected Rigidbody _rb;
    public delegate void OnReachTrackEndDelegate();
    public OnReachTrackEndDelegate onReachTrackEndDelegate;
    // Update is called once per frame

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        AddRigidBody();
    }

    protected virtual void Move()
    {
        
    }

    private bool HasRigidBody()
    {
        return _rb != null;   
    }

    // Add a default rigid body to the game object if it doesn't have one
    protected virtual void AddRigidBody()
    {
        if (!HasRigidBody())
        {
            _rb = gameObject.AddComponent<Rigidbody>();
            _rb.mass = 1;
            _rb.drag = 0;
            _rb.angularDrag = 0.05f;
            _rb.useGravity = true;
            _rb.isKinematic = false;

            _rb.interpolation = RigidbodyInterpolation.None;
            _rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
            _rb.freezeRotation = true;    
        }

        ModifyRigidBody();
    }

    protected virtual void ModifyRigidBody()
    {

    }

    public bool IsKinematic()
    {
        return _rb?.isKinematic ?? false;
    }

    // Check if the animal has reached the end of the track
    // Call the delegate if it has
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "TrackEnd")
        {
            onReachTrackEndDelegate();
        }
    }
}
