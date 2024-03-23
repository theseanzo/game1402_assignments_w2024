using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class A2Animal : MonoBehaviour
{
    public GameObject[] Animals;   
    // Update is called once per frame

    protected virtual void Move()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("TrackEnd"))
        {
            Destroy(collision.gameObject);
        }
    }

}
