using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    public float distance = 2f;
    #endregion

    Rigidbody _rb;
    Vector3 _moveVector;
    bool canMove = false;

    private void Awake()
    {
       _rb = GetComponent<Rigidbody>();
       _rb.freezeRotation = true;
       _rb.constraints = RigidbodyConstraints.FreezePositionY;
       _rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; //allows the animals to collide with static and dynamic rbs
    }

    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion
    }

    public override void Move()
    {
        canMove = true;
    }

    public void FixedUpdate()
    {
        if (canMove && Input.GetKeyDown(KeyCode.Alpha3))
        {
            Vector3 move = transform.forward * distance * Time.fixedDeltaTime;

            _rb.MovePosition(_rb.position + move);
        }

    }

}
