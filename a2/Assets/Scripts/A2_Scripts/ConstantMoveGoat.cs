using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    #endregion
    A2Animal cGoat;
    TrackEnd trackEnd1;
    public bool Goat = false;
    float distance;

    protected void Start()
    {
        cGoat = FindObjectOfType<ConstantMoveGoat>();
        speed = 3.0f;
        trackEnd1 = FindObjectOfType<TrackEnd>();
        end = trackEnd1.transform;
        animalTransform = cGoat.transform;
        Goat = false;
    }
    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Goat = true;
        }
        if (Goat)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Goat = false;
            #endregion
        }

        if (cGoat != null)
        {
            distance = Vector3.Distance(cGoat.transform.position, end.position);
            Debug.Log("Distance between objects: " + distance);
        }

        if (distance <= 2.0f)
        {
            Destroy(this.gameObject);
        }

    }
}
