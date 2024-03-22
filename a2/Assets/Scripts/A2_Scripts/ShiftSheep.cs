using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    public float distance = 2f;
    #endregion

    A2Animal _animal;
    Rigidbody _rbShift;
    TrackSpawner _trackShift;
    Vector3 _moveVector;

    private void Awake()
    {
       _animal = GetComponent<A2Animal>();
       _trackShift = GetComponent<TrackSpawner>();

       _rbShift = GetComponent<Rigidbody>();
       _rbShift.freezeRotation = true;
       _rbShift.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; //allows the animals to collide with static and dynamic rbs
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
        _moveVector = _trackShift.movement * Time.fixedDeltaTime;
        _rbShift.MovePosition(_rbShift.position + _moveVector * distance);
        
    }
}
