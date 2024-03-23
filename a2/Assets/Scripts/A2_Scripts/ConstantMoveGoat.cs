using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion

    bool canMove = false;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //rb.isKinematic = true;
        //rb.constraints = RigidbodyConstraints.FreezePositionY;
    }

    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Move(); //can change move functions
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
            Vector3 move = transform.forward * speed * Time.fixedDeltaTime;

            rb.MovePosition(rb.position + move);
        }
    }
}
