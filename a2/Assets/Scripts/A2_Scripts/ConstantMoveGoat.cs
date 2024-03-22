using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion
    bool isMoving;

    IEnumerator couroutine;

    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Move(); //can change move functions
        #endregion
    }

    protected override void Move()
    {
        if (!isMoving)
        {
            isMoving = true;
            couroutine = MoveGoat();
            StartCoroutine(couroutine);
        }
        else
        {
            isMoving = false;
            StopCoroutine(couroutine);
        }
    }

    IEnumerator MoveGoat()
    {
        while (true)
        {
            _rb?.MovePosition(_rb.position + Vector3.right * speed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}
