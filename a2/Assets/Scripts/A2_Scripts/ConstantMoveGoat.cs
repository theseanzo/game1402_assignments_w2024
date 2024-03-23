using System;
using Unity.VisualScripting;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion
    
    private bool isMoving = false;

    private Rigidbody rigidBodyComponent;

    private void Awake()
    {
        rigidBodyComponent = this.AddComponent<Rigidbody>();
        rigidBodyComponent.mass = 1;
        rigidBodyComponent.drag = 0;
        rigidBodyComponent.useGravity = true;
        rigidBodyComponent.isKinematic = true;
        rigidBodyComponent.collisionDetectionMode = CollisionDetectionMode.Discrete;
        rigidBodyComponent.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Move(); 
        #endregion
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }    
    }

    protected override void Move()
    {
        isMoving = !isMoving; 
    }

}
