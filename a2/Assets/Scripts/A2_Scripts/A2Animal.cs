using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class A2Animal : MonoBehaviour
{
    public Vector3 animalDirection;
    public Vector3 animalDestination;
    // Update is called once per frame
    private void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        Rigidbody newRB = GetComponent<Rigidbody>();
        newRB.freezeRotation = true;
    }
    private void Update()
    {

      //  if (Vector3.Distance(transform.position, animalDestination) < 3)
       // {
       //     Destroy(gameObject);
       // }
    }


    //public void OnCollisionEnter(Collision collision)
   // {
     //   if (collision.gameObject.tag == "Finish")
      //  {
       //     Destroy(gameObject);
     //   }

    //}
}
