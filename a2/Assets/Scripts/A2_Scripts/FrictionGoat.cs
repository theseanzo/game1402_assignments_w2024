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
    private float extraspeed = 3f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            rb.AddForce(transform.forward * speed * extraspeed );
        }

    }
}
