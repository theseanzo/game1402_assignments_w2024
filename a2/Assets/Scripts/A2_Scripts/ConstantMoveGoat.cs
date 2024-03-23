using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; //freezing the rotation
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
    public void FixedUpdate()
    {
        if (canMove)
        {
            Vector3 move = transform.forward * speed * Time.fixedDeltaTime; //moves the sheep forward in constant speed and velocity

            rb.MovePosition(rb.position + move);
        }
    }
}
