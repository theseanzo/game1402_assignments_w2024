using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    float speedMultiplier = 220f; //I'd modify the speed value directly, but I can't touch that variable! This probably means my method is wrong.
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

    protected override void Move()
    {
        _rb.AddForce(transform.forward * (speed * speedMultiplier));
    }
}
