using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class A2Animal : MonoBehaviour
{

    public Transform endLocation;

    protected virtual void Move()
    {
        
    }

    private void FixedUpdate()
    {
        float dis = Vector3.Distance(transform.position, endLocation.position);
        if (dis <= 1.0)
        {
            Destroy(this.gameObject);
        }
    }
}