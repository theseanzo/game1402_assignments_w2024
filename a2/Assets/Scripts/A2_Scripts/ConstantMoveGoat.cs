using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    bool currentlyMoving = false;
    #endregion
    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Move(); //can change move functions
        #endregion
    }
    public new void Awake()
    {
        base.Awake();
        rb.isKinematic = true;
    }
    protected override void Move()
    {
        base.Move();
        //rb.isKinematic = true; debug hack
        Debug.Log(gameObject.name + "Input");
        currentlyMoving = currentlyMoving ? false : true;
    }

    private void FixedUpdate()
    {
        if (currentlyMoving)
        {
            rb.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
