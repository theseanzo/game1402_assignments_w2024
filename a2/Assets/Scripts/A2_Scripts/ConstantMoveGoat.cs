using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion
    
    private float scanDistance = 1f;
    private float moveDistance = 1f;
    private bool isMoving = false;
    private Collider trackEndCollider;

    private void Start()
    {
        trackEndCollider = GameObject.Find("TrackEnd").GetComponent<Collider>();
        trackEndCollider.enabled = true;
    }

    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Move(); //can change move functions
        #endregion
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Move(); // Move the goat if isMoving is true
        }
    }

    protected override void Move()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isMoving = !isMoving;
            Debug.Log(isMoving ? "Goat started moving" : "Goat stopped moving");
        }

        if (isMoving)
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);

            // Perform a raycast in front of the goat to check for collisions with wood plank and move it
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, scanDistance))
            {
                if (hit.collider.gameObject.name.Contains("Wood_02 (6)"))
                {
                    hit.collider.transform.Translate(Vector3.up * moveDistance);
                }
            }
        }
    }
}

