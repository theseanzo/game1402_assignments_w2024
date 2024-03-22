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
    private bool isMoving = false;

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
        if (!isMoving)
        {
            rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
            isMoving = true;
        }
    }

    private void FixedUpdate()
    {
        if (isMoving && rb.velocity.magnitude < 0.1f)
        {
            isMoving = false;
            rb.velocity = Vector3.zero;
        }
    }
}