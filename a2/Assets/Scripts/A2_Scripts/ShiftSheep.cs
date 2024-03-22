using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float distance = 2f;
    #endregion

    Vector3 _targetPosition;
    Vector3 _sheepVelocity;

    bool _moveSheep = false;
    float _moveSpeed = 1f;

    private void Start()
    {
        distance = 11f;
        _moveSheep = false;

        _targetPosition = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion
    }

    // The assignment said to make this guy move smoothly, and so I decided to use a lerp on the rigidbody's position. The target position is set on start, and then just waits for your button press.
    private void FixedUpdate()
    {
        if(_moveSheep)
        {
            rb.position = Vector3.Lerp(rb.position, _targetPosition, _moveSpeed * Time.fixedDeltaTime);
        }
    }

    protected override void Move()
    {
        _moveSheep = true;
    }
}
