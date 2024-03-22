using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
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

    void FixedUpdate()
    {
        if (_isMoving)
        {
            _rigidbody.position += transform.forward * speed * Time.fixedDeltaTime;
        }
    }

    protected override void Move()
    {
        _isMoving = !_isMoving;
    }
}
