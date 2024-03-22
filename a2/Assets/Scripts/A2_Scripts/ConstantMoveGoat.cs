using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion
    
    private bool isMoving = false;
    
    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Move(); 
        #endregion
        
        if (isMoving)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }
    
    public void Move()
    {
        isMoving = !isMoving; 
    }

}
