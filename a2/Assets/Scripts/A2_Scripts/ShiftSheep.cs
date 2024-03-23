using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float distance = 2f;
    
    [SerializeField]
    bool isMoving = false;
    [SerializeField]
    float startTime;
    [SerializeField]
    Vector3 startPosition;
    [SerializeField]
    Vector3 endPosition;
    [SerializeField]
    float moveDuration = 1.0f; // Duration to move over the specified distance
    #endregion
    
    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion
        
        if (isMoving)
        {
            ContinueMoving();
            // Debug.Log("MOVEE");
        }
    }
    private void Move()
    {
        // Debug.Log("move called");

        startPosition = transform.position;
        endPosition = startPosition + transform.forward * distance;
        startTime = Time.time;
        isMoving = true;
    }

    void ContinueMoving()
    {
        float elapsedTime = Time.time - startTime;
        float timing = elapsedTime / moveDuration; 

        transform.position = Vector3.Lerp(startPosition, endPosition, timing);

        if (timing >= 1)
        {
            // Debug.Log("stop moving");

            isMoving = false; 
        }
    }
}