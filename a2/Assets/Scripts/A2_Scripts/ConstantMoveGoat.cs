using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    //Rigidbody rb;
    bool moveToggle = false;
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
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
        moveToggle = !moveToggle;
    }
    private void FixedUpdate()
    {
        if (moveToggle)
        {
            _rb.MovePosition(_rb.position + speed * Time.fixedDeltaTime * _rb.transform.forward);
        }

    }

}
