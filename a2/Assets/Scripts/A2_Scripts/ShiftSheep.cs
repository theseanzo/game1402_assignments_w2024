using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float distance = 2f;
    #endregion

    private float _duration = 0.5f;
    private Coroutine _shiftMoveCoroutine;
    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion
    }

    // Start a coroutine to move the animal
    // If the coroutine is already running, do nothing
    protected override void Move()
    {
        if (_shiftMoveCoroutine == null)
        {
            _shiftMoveCoroutine = StartCoroutine(ShiftMove());
        }
    }

    // Move the animal forward by a set distance smoothly over a set duration
    IEnumerator ShiftMove()
    {
        float time = 0;
        Vector3 positionStart = transform.localPosition;
        Vector3 positionTarget = positionStart + transform.forward * distance;

        while (time < _duration)
        {
            time += Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, positionTarget, distance / _duration * Time.deltaTime);
            yield return null;
        }

        transform.localPosition = positionTarget;
        _shiftMoveCoroutine = null;
    }
}
