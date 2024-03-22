using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion

    bool currentlyMoving = false;

    private void Start()
    {
        rb.isKinematic = true;
    }

    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Move(); //can change move functions
        #endregion
    }

    // I'm setting this up this way, because the goat wouldn't move if I put it all under the Move() function, and so I have the move function set a bool, which FixedUpdate() then looks for, and then moves the goat or doesn't

    void FixedUpdate()
    {
        if (currentlyMoving)
        {
            rb.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    protected override void Move()
    {
        currentlyMoving = currentlyMoving ? false : true;
    }
}
