using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSheep : A2Animal
{
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

    public override void Move()
    {
       
    }
}
