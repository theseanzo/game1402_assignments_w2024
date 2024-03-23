using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion
    
    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Move(); //can change move functions
        #endregion

        if(_shouldMove)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    protected override void Move()
    {
        _shouldMove = !_shouldMove;
    }

    protected override void AddRigidBody()
    {
        base.AddRigidBody();
    }

	protected override void ModifyRigidBody()
	{
        base.ModifyRigidBody();
		_rb.isKinematic = true;
	}
}
