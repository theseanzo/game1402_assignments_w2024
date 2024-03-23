using System.Collections;
using UnityEngine;

public class ShiftSheep : A2Animal
{
    /// <summary>
    /// Controls the sheep's movement towards a specified distance smoothly, for fixed duration
    /// </summary>
    
    #region Sean code do not touch
    [SerializeField]
    float distance = 2f;
    #endregion

    private bool _currentlyMoving;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Move();
    }

    protected override void Move()
    {
        if (_currentlyMoving) return;
        _currentlyMoving = true;
        StartCoroutine(MoveDistance());
    }


    private IEnumerator MoveDistance()
    {
        Vector3 start = transform.position;
        Vector3 end = start + transform.forward * distance; 

        float duration = 1.0f; 
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, end, (distance / duration) * Time.deltaTime);
            yield return null;
        }

        _currentlyMoving = false;
        transform.position = end;
    }
}

