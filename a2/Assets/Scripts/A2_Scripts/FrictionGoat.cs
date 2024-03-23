using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion
    [SerializeField]
    float thrust = 20f;
    [SerializeField]
    float vardrag = 2f;
    //simple force multiplier
    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Move();
        #endregion
    }
    protected override void Move()
    {
        // This is super hacky but i was running into issues spawning the frictiongoats and having a drag of 0, somehow
        rb.drag = vardrag;
        Debug.Log("Drag is" + vardrag + "Actual drag is" + rb.drag);
        // hence me checking "actual drag" vs "var drag"
        rb.AddForce(speed * thrust, 0, 0);
        Debug.Log("Should be moving");
        Debug.Log(gameObject.name + "Input");
    }
    public new void Awake()
    {
        base.Awake();
    }
}
