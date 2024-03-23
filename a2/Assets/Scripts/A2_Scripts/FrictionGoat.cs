using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion

    Rigidbody _rb;
    Vector3 _moveVector;
    bool canMove = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _rb.constraints = RigidbodyConstraints.FreezePositionY;
        _rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; //allows the animals to collide with static and dynamic rbs
    }

    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Move();
        #endregion
    }
    public override void Move()
    {
        canMove = !canMove;
    }
    public void FixedUpdate()
    {
        if (canMove)
        {
            Vector3 move = transform.forward * speed;
           _rb.AddForce(_rb.position + move);
        }
    }
}
