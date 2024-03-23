using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    bool canMove = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.isKinematic = true;


    }
    #endregion
    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Move(); //can change move functions
        #endregion
    }
    protected override void Move()
    {
        canMove = !canMove;
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            Vector3 move = transform.forward * speed * Time.fixedDeltaTime;

            rb.MovePosition(rb.position + move);

        }

    }
}
