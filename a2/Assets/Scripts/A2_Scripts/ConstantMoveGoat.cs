using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion

    Rigidbody _rb;
    public bool _canStop = false;
    Vector3 _moveVector;
    public TrackSpawner _spawnerRef;
    A2Animal _animal;

    private void Awake()
    {
        _animal = GetComponent<A2Animal>();
        _spawnerRef = FindObjectOfType<TrackSpawner>();
        _animal._canMove = true;

        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _rb.isKinematic = true;
        _rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; //allows the animals to collide with static and dynamic rbs
    }

    public override void Move()
    {
        if (_animal._canMove == true)
        {
            _canStop = true;
            _moveVector = _spawnerRef.movement;
            _rb.MovePosition(_rb.position + _moveVector * speed * Time.fixedDeltaTime);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1) && _canStop == true)
        {
            StopMove();
            _canStop = false;
        }
    }

    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Move(); //can change move functions
        #endregion
    }
    public void StopMove()
    {
        speed = 0;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _canMove = true;
        }
    }
}
