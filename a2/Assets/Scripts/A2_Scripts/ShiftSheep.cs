using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float distance = 2f;
    #endregion
    bool isMoving = false;
    float moveStep;
    Vector3 startPos;

    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion
        if (Vector3.Distance(transform.position, animalDestination) < 1)
        {
            Destroy(gameObject);
        }
        if (isMoving)
        {
            moveStep = distance * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, animalDestination, moveStep);
            if (Vector3.Distance(startPos, transform.position) > distance)
            {
                isMoving = false;
            }
        }

    }
    private void Move()
    {
        if (!isMoving)
        {
            isMoving = true;
            startPos = transform.position;
        }

    }


}
