using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float distance = 2f;
    #endregion
    IEnumerator coroutine;
    Vector3 newPosition;

    private void Update()
    {
        #region Sean code do not touch
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
        #endregion
    }

    protected override void Move()
    {
        newPosition = new Vector3(_rb.position.x + distance, _rb.position.y, _rb.position.z);
        coroutine = MoveSheep();
        StartCoroutine(coroutine);
    }

    IEnumerator MoveSheep()
    {
        while (true)
        {
            float interpolation = .5f;
            _rb.position = Vector3.Lerp(_rb.position, newPosition, interpolation * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}
