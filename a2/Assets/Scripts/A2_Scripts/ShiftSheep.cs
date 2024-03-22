using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float distance = 2f;
    #endregion
    
    bool isMoving;
    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion
    }
    
    private void Move()
    {
        if (isMoving == false)
        {
            StartCoroutine(MoveDistance());
            isMoving = true;
        }
    }

    IEnumerator MoveDistance()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + transform.forward * distance; 

        float duration = 1.0f; 
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, (distance / duration) * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isMoving = false;

        transform.position = endPosition;
    }
}

