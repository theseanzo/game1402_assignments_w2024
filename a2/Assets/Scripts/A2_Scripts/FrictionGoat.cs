using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion
    private bool isMoving = false;
    

    private void Start()
    {
        base.Start(); 
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Move();
        #endregion

        if (isMoving)
        {
            ApplyFriction();

            _rigidbody.MovePosition(transform.position + transform.forward * speed* Time.deltaTime);
        }
    }
    protected override void Move()
    {
        isMoving = true;
    }
    private void ApplyFriction()
    {
        Vector3 frictionForce = -_rigidbody.velocity.normalized * _rigidbody.drag;

        _rigidbody.AddForce(frictionForce, ForceMode.Acceleration);
    }
}
