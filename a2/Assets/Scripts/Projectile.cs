using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float timeToDie = .01f, timeAlive = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Death", timeAlive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Death", timeToDie);
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }
}
