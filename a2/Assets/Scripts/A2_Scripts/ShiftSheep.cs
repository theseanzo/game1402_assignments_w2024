using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    GameObject track;
    TrackSpawner spawner;
    Vector3 destination;
    bool moveToggle = false;
    #region Sean code do not touch
    [SerializeField]
    float distance = 2f;
    #endregion
    protected override void Awake()
    {
        base.Awake();
        track = GameObject.Find("Track3");
        spawner = track.GetComponent<TrackSpawner>();
        destination = spawner.trueEndLocation.position;
    }
    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion
    }
    protected override void Move()
    {
        //Vector3 direction = (destination - transform.position).normalized;
        moveToggle = true;
    }
    private void FixedUpdate()
    {
        if(moveToggle)
            transform.position = Vector3.Lerp(transform.position, destination, 0.05f);
    }
}
