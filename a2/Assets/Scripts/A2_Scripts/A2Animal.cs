using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
public class A2Animal : MonoBehaviour
{
    protected Rigidbody _rigidbody;
   
    // Update is called once per frame

    public void Start()
    {
     _rigidbody = GetComponent<Rigidbody>();

        if (_rigidbody == null)
        {
            _rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        _rigidbody.mass = 1f;
        _rigidbody.drag = 1;
       

        _rigidbody.freezeRotation = true;
    }

    protected virtual void Move()
    {
       
    }

   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<TrackEnd>()!= null)
        {
            Destroy(gameObject);
        }
    }

}
