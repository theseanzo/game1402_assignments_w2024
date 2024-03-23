using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    public float distance = 2f;
    #endregion

    Rigidbody _rb;
    Vector3 _moveVector;
    //canMove = false;

    private void Awake()
    {
       _rb = GetComponent<Rigidbody>();
       _rb.freezeRotation = true;
       _rb.constraints = RigidbodyConstraints.FreezePositionY;
       _rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; //allows the animals to collide with static and dynamic rbs
    }


    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion
    }

    public void FixedUpdate()
    {
        if (canMove && Input.GetKeyDown(KeyCode.Alpha3)) //if the sheep can move and 3 is being pressed
        {
            Vector3 move = transform.forward * distance * Time.fixedDeltaTime; //move it forwards according to the space settled beforehand within a time period

            _rb.MovePosition(_rb.position + move); //moves the rigidbody along with the vector 3 made which moves the player

            //all of this only happens when the player presses the key
        }

    }

}
