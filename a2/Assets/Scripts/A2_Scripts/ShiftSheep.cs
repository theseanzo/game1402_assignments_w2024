using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    Vector3 lerpstart;
    Vector3 lerpend;
    float moveduration = 0.5f;
    float starttime;
    bool currentlyMoving = false;
    #region Sean code do not touch
    [SerializeField]
    float distance = 2f;
    #endregion
    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion
    }
    protected override void Move()
    {
        Debug.Log(gameObject.name + "Input");
        base.Move();
        StartCoroutine(MoveDistance());
    }
    IEnumerator MoveDistance()
    {
        if (currentlyMoving == false)
        {
            currentlyMoving = true;
            lerpstart = transform.position;
            lerpend = lerpstart + transform.forward * distance;
            starttime = Time.time;

            while (Time.time < starttime + moveduration)
            {
                float lerptime = (Time.time - starttime) / moveduration;
                transform.position = Vector3.Lerp(lerpstart, lerpend, lerptime);
                yield return null;
            }

            lerpend = transform.position;
            currentlyMoving = false;
        }
        else
        {
            Debug.Log("Already moving.. Please wait! C:");
        }
    }

}
