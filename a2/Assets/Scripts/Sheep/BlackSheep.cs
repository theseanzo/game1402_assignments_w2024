using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSheep : MonoBehaviour
{
    [SerializeField]
    float timeAlive = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SadDeath", timeAlive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SadDeath()
    {
        Debug.Log("I had a bahhhhhd life");
        Destroy(gameObject);

    }
}
