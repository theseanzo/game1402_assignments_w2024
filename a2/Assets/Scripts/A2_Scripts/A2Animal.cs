using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class A2Animal : MonoBehaviour
{
    protected Rigidbody rb;
    bool isMoving;
    // Update is called once per frame

    protected virtual void Move()
    {
     // I misread the instructions and assumed all animals must be able to start and restart...
     // I commented it out.
     //if (isMoving == false)
     //{
     // isMoving = true;
     // rb.WakeUp();
     //  Debug.Log(gameObject.name + "Calling Wakeup");
     //}
     //  else
     //  {
     //      isMoving = false;
     //     Pause();
     //     Debug.Log(gameObject.name + "Was already moving.. Calling Sleep");
     //  }
     //
     }

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

        //using constraints caused me so much issues why did i do this
        //note to self, using multiple constraint lines does NOT turn them on and off, but just sets it ALL to what is specified in the final line
    }
    public void Pause()
    {
        rb.Sleep();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log (gameObject.name + "collided" + other.gameObject.name);
        if (other.gameObject.name == "TrackEnd")
        {
            Destroy(gameObject);
            Debug.Log (gameObject.name + "Destroyed, should now be null");
        }
    }
}
