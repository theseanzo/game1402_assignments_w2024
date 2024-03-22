using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion

    float friction = 2f;

    private void Start()
    {
        rb.drag = friction;
        speed = 30f;
    }

    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Move();
        #endregion
    }

    // This one was the easiest, press a button, add a force

    protected override void Move()
    {
        rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
    }
}
