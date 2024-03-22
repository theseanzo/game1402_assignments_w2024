using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    float distance;
    A2Animal Sheep;
    TrackEnd trackEnd2;
    #endregion

    protected void Start()
    {
        speed = 0.5f;
        Sheep = FindObjectOfType<ShiftSheep>();
        trackEnd2 = FindObjectOfType<TrackEnd>();
        end = trackEnd2.transform;
        animalTransform = Sheep.transform;
    }
    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Move();

        }

        if (Sheep != null)
        {
            distance = Vector3.Distance(Sheep.transform.position, end.position);
            Debug.Log("Distance between objects: " + distance);
        }

        if (distance <= 2.5f)
        {
            Destroy(this.gameObject);
        }


        #endregion
    }
}
