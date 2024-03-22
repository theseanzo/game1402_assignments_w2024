using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhibit1 : Exhibit
{
    [SerializeField]
    Transform spawn1, spawn2;

    [SerializeField]
    BlackSheep sheepPrefab1, sheepPrefab2;

    [SerializeField]
    float sheepSpeed = 20f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RunSimulation() //I want this to happen any time that the Steak is hit. However, I do not want to know that the steak was hit, or about the steak at all. I simply want this function called when something happens in the scene
    {
        Debug.Log("Run the simulation, please and thank you");
        BlackSheep sheep1 = Instantiate(sheepPrefab1, spawn1.position, Quaternion.identity);
        BlackSheep sheep2 = Instantiate(sheepPrefab2, spawn2.position, Quaternion.identity);
        //We want to shoot the two sheep towards one another, so we need to figure out the direction vector between them
        Vector3 direction = (spawn2.transform.position - spawn1.transform.position).normalized; //We always want to normalize direction vectors, and the reason for this is that we don't want to calculate any information when taking into consideration how far they are apart. Normalizing means the length of the vector is 1. This is very important to do if we are going to use the vector for Physics, because we will multiply a force by this direction
        //if the vector is, for example, (2,0) and then we multiply it for physics as 20*(2,0) then our resultant speed is going to be (40,0). However, if normalized, it would be (1,0) so the resultant speed would be (20,0)
        sheep1.GetComponent<Rigidbody>().velocity = direction * sheepSpeed;
        sheep2.GetComponent<Rigidbody>().velocity = -direction * sheepSpeed;


    }

    
}
