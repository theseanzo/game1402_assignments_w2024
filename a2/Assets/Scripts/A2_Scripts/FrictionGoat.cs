using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion
    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Move();
        #endregion
    }

    // Use force to move the animal
    protected override void Move()
    {
        _shouldMove = true;
    }

    private void FixedUpdate()
    {
        if (_shouldMove)
        {
            _rb.AddForce(transform.forward * speed, ForceMode.Impulse);
            _shouldMove = false;
        }
    }
}
