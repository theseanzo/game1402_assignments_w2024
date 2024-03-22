using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class A2Animal : MonoBehaviour
{
    Rigidbody _rb;

    private void Awake()
    {
        _rb = this.gameObject.GetComponent<Rigidbody>();
        if (!_rb)
            _rb = this.gameObject.AddComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _rb.isKinematic = true;
    }

    // Update is called once per frame

    protected virtual void Move()
    {
        
    }

    private void FixedUpdate()
    {
        if (_rb)
            _rb?.MovePosition(_rb.position + Vector3.right * 3f * Time.fixedDeltaTime); //set temporary movement
    }
}
