using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrackEnd : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;
        A2Animal animalBody = collidedObject.GetComponent<A2Animal>();

        if (animalBody != null)
        {
            DestroyAnimal(collidedObject);
        }
    }

    private void DestroyAnimal(GameObject animalObject)
    {
        Destroy(animalObject);
    }
    
      
}