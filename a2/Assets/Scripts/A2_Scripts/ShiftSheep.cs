using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float distance = 2f;
    #endregion

    private float moveSpeed = 2f; // Adjust the speed as needed
    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion

        if (isMoving)
        {
            targetPosition = transform.position + transform.forward * distance;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                Debug.Log("Sheep reached the desired distance.");
            }
        }
    }

    protected override void Move()
    {
        isMoving = true; // Start moving
        Debug.Log("Sheep started moving a distance");
    }
}
