using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody))] //require component forces us to take on a component

public class A2Animal : MonoBehaviour
{
    #region variables
    Rigidbody _rb;
    Vector3 _moveVector;
    bool _canStop = false;
    [SerializeField]
    public float _speed;
    #endregion

    #region references
    public TrackSpawner _spawnerRef;
    public ConstantMoveGoat _constantGoat;
    #endregion 
    // Update is called once per frame
    void Awake()
    {
        _spawnerRef = FindObjectOfType<TrackSpawner>();
        _constantGoat = FindObjectOfType<ConstantMoveGoat>();

        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        _rb.isKinematic = true;
        _rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; //allows the animals to collide with static and dynamic rbs
    }
    public void Move()
    {
        if (_canStop == false)
        {
            _moveVector = (_spawnerRef.endPos.position - _spawnerRef.spawnPos.position).normalized;
            _rb.MovePosition(_rb.position + _moveVector * _speed * Time.fixedDeltaTime);
            _canStop = true;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1) && _canStop == true)
        {
            _constantGoat.StopMove();
            _canStop = false;
        }
    }

}
