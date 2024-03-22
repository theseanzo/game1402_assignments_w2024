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
    private bool _collided = false;

    private void Start()
    {
        base.Start();
        _rigidbody = GetComponent<Rigidbody>();
         
    }
    private void Update()
    {
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Move(); //can change move functions
        #endregion

        if (isMoving)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }


    protected override void Move()
    {
        isMoving = !isMoving;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null && !_collided)
        {
            _collided= true;
            StartCoroutine(DisableKinematic());
        }
    }
    IEnumerator DisableKinematic()
    {
        yield return new WaitForSeconds(1f);
        _rigidbody.isKinematic = true;
    }

}
