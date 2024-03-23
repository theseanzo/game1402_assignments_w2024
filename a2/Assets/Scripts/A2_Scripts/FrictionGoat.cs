using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion
    float goatFriction = 1f;

    private void Start()
    {
        body.drag = goatFriction;
        speed = 22f;
    }
    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Move();
        #endregion

     
    }
    protected override void Move()
    {
        base.Move();
        body.AddForce(Vector3.right * speed, ForceMode.Impulse);
    }
}
