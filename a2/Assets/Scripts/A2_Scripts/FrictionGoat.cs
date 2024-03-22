using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion

    public TrackSpawner _spawnerRefFriction;
    Rigidbody _rbFriction;
    Vector3 _moveVector;
    A2Animal _animal;

    private void Awake()
    {
        _spawnerRefFriction = FindObjectOfType<TrackSpawner>();
        _animal = GetComponent<A2Animal>();
        _animal._canMove = true;

        _rbFriction = GetComponent<Rigidbody>();
        _rbFriction.freezeRotation = true;
        _rbFriction.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; //allows the animals to collide with static and dynamic rbs
    }

    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Move();
        #endregion
    }
    public override void Move()
    {
        _moveVector = _spawnerRefFriction.movement;
        _rbFriction.MovePosition(_rbFriction.position + _moveVector * speed * Time.fixedDeltaTime);
    }
}
