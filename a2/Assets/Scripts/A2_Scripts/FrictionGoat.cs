using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    #region Sean code do not touch
    float speed = 3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationY;
        rb.constraints = RigidbodyConstraints.FreezePositionY;

    }
    #endregion
    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Move();
        }

        #endregion
    }
    protected override void Move()
    {
        rb.AddForce(transform.forward * speed * 10);
    }
}
