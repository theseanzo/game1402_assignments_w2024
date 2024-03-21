using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicCar : MonoBehaviour
{
    Rigidbody _rb;
    Vector3 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void SetMove(Vector3 mVector)
    {
        this.moveVector = mVector;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + moveVector * Time.fixedDeltaTime);
    }
}
