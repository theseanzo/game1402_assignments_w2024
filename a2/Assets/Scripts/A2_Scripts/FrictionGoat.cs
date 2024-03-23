using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    [SerializeField]
    float speed = 3f;

    private Rigidbody rb;
    private bool isRunning = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
         Debug.LogError("Rigidbody component is missing on the goat!");
         return;
        }
    }

    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Move();
        #endregion
    }

    public void Move()
    {
        if (!isRunning)
        {
            rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
            isRunning = true;
        }
    }

    private void FixedUpdate()
    {
        if (isRunning && rb.velocity.magnitude < 0.1f)
        {
            isRunning = false;
            rb.velocity = Vector3.zero;
        }
    }
}