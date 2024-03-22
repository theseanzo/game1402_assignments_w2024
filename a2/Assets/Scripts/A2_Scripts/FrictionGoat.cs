using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion

    private float friction = 2f;

    private float currentSpeed;

    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Move();
        #endregion
    }

    private void FixedUpdate()
    {
        // Apply friction to slow down the goat
        if (currentSpeed > 0)
        {
            currentSpeed -= Time.fixedDeltaTime * friction;
            transform.Translate(Vector3.forward * currentSpeed * Time.fixedDeltaTime);
        }
    }

    protected override void Move()
    {
        // Start moving when the key is pressed
        currentSpeed = speed;
        Debug.Log("Goat started moving with friction");
    }
}

