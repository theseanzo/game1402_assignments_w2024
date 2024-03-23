using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float distance = 2f;
    #endregion
    float duration = 1.0f; 
    Vector3 endPosition;
    
    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion
    }

    private void FixedUpdate()
    {
        if (MovingGoat)
        {
            if (MovingGoat || Vector3.Distance(transform.position, endPosition) > 0.01f) 
            {
                float speed = distance / duration; 
                transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
                MovingGoat = true;
            }
            else
            {
                Debug.Log("Movement completed.");
                MovingGoat = false;
            }
        }
    }

    private void Move()
    {
        endPosition = transform.position + transform.forward * distance;
        MovingGoat = true;
    }

}

