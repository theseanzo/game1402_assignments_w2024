using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public UnityEvent Hit; //A UnityEvent uses what's known as the Observer pattern (which you will learn about more next semester)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I am triggered");
        if (other.gameObject.GetComponent<Projectile>())
        {
            Hit?.Invoke(); //we invoke our event, which means to broadcast or call the event out. A "Hey, I was hit message" to anyone who wants to listen. Sort of like a fire alarm
            Debug.Log("You even hit me with a projectile");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("You hit me");
        if (collision.gameObject.GetComponent<Projectile>())
        {
            Hit?.Invoke(); //we invoke our event, which means to broadcast or call the event out. A "Hey, I was hit message" to anyone who wants to listen. Sort of like a fire alarm
            Debug.Log("You even hit me with a projectile");
        }
    }
}
