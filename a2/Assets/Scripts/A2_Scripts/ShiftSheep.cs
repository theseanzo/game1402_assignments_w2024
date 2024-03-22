using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float distance = 2f;
    #endregion

    Vector3 _targetPos;

    float _lerpTime = 0.5f;

    void Start()
    {
        distance = 12f;
        _targetPos = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
    }
    
    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion
    }

    void FixedUpdate()
    {
        if (_isMoving)
        {
            _rigidbody.position = Vector3.Lerp(_rigidbody.position, _targetPos, _lerpTime * Time.fixedDeltaTime);
        }
    }

    protected override void Move()
    {
        _isMoving = true;
    }


}
