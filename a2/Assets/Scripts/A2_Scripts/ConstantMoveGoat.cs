using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion

    bool isMoving = false;
    private void Start()
    {
        body.isKinematic = true;
    }
    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Move(); //can change move functions
        #endregion
        
    }

    private void FixedUpdate()
    {
        if(isMoving)
        {
            body.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    protected override void Move()
    {
        isMoving = isMoving ? false : true;
    }


}
