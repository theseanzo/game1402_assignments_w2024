using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion

    Rigidbody _rb; 
    Vector3 _moveVector; //vector which will be responsible for movement

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _rb.constraints = RigidbodyConstraints.FreezeRotationY;
        _rb.constraints = RigidbodyConstraints.FreezePositionY; //freezing the rotation and position in Y, i believe the freezerotation is just rotating it in general
    }

    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Move();
        #endregion
    }

    public void FixedUpdate()
    {
        if (canMove)
        {
            //Vector3 move = transform.forward * speed * Time.fixedDeltaTime;
            //_rb.MovePosition(_rb.position + move);
            _rb.AddForce(Vector3.right * speed); //adds force to the sheep's body according to the accelleration
        }
    }
}
