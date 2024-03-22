using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    Rigidbody rb;
    bool isMoving = false;
    #endregion
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Move(); //can change move functions
        #endregion
        if (Vector3.Distance(transform.position, animalDestination) < 1)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.MovePosition(transform.position + animalDirection * speed * Time.deltaTime);
        }
    }
    public void Move()
    { 
        if (!isMoving)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        
    }

}
