using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionGoat : A2Animal
{
    #region Sean code do not touch
    [SerializeField]
    float speed = 3f;
    #endregion
    Rigidbody rb;
    private void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.mass = 1;
        rb.drag = 1.5f;
        speed = 15;
    }
    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Move();
        #endregion
        if (Vector3.Distance(transform.position, animalDestination) < 1)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Move()
    {
        gameObject.GetComponent<Rigidbody>().velocity = animalDirection * speed;
    }
}
