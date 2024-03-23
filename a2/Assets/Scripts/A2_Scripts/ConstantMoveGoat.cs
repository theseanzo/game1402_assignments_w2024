using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion
    public Rigidbody rb;
    private bool ismoving = false;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Move(); //can change move functions
        #endregion
    }
    public void Move()
    {
        ismoving= !ismoving;
        if (ismoving)
        {
            rb.velocity = transform.forward * speed;
        }
        else
        { rb.velocity = Vector3.zero; }
    }
}
