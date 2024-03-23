using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float distance = 2f;
    #endregion

    Vector3 targetDestination;
    Vector3 sheepVelocity; 

    bool moveSheep = false;
    float moveSpeed = 1f;

    private void Start()
    {
        distance = 15f;
        moveSheep = false; 

        targetDestination = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
    }
    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion
    }

    private void FixedUpdate()
    {
        if(moveSheep)
        {
            body.position = Vector3.Lerp(body.position, targetDestination, moveSpeed * Time.fixedDeltaTime);
        }
    }

    protected override void Move()
    {
        base.Move();
        moveSheep = true;
    }
}
