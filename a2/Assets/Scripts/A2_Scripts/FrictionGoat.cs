using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion
    
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
         rb.AddForce(Vector3.right * speed, ForceMode.VelocityChange);
         MovingGoat = true;
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < 0.1)
        {
            MovingGoat = false;
        }
    }
}