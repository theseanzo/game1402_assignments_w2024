using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion

    [SerializeField]
    float _friction = 12f;

    void Start()
    {
        _isMoving = false;
        _rigidbody.drag = _friction;
        _rigidbody.isKinematic = false;
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
        _isMoving = true;
    }

    void FixedUpdate()
    {
        if (_isMoving)
        {
            _rigidbody.AddForce(Vector3.right * speed, ForceMode.Impulse);
        }
    }
}
