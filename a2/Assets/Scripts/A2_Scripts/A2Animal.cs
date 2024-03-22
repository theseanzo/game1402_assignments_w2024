using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class A2Animal : MonoBehaviour
{
    protected Rigidbody animalRigidbody;
    private void Awake()
    {
        animalRigidbody = GetComponent<Rigidbody>();
        animalRigidbody.freezeRotation = true;
    }

    protected virtual void Move()
    {
        
    }

}
