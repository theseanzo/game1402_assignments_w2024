using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float distance = 2f;
    #endregion

    Coroutine moveCoroutine;
    Transform trackEnd;

    private void Start()
    {
        TrackEnd[] trackEnds = FindObjectsOfType<TrackEnd>();

        if (trackEnds.Length >= 3)
        {
         
            trackEnd = trackEnds[1].transform;
        }
    }
    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion
    }

    void StartMoving()
    {
        moveCoroutine = StartCoroutine(MoveToEnd());
    }

    IEnumerator MoveToEnd()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = trackEnd.position;

        float startTime = Time.time;
        float trackLength = Vector3.Distance(startPosition, endPosition);

        float distTraveled = 0f;
        while (distTraveled< trackLength)
        {
            float trackFraction = distTraveled / trackLength;
            transform.position = Vector3.Lerp(startPosition, endPosition, trackFraction);
            distTraveled += Time.deltaTime * distance;
            yield return null;
        }

        transform.position = endPosition;
        
    }
    bool IsSheepMoving()
    {
        return moveCoroutine != null;
    }
    protected override void Move()
    {
        if (!IsSheepMoving())
            StartMoving();

    }
}
