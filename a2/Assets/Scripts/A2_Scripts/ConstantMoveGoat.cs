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

    IEnumerator coroutine;

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
            coroutine = MoveGoat();
            StartCoroutine(coroutine);
        }
        else
        {
            isMoving = false;
            StopCoroutine(coroutine);
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
