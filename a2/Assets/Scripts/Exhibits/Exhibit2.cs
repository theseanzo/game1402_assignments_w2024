using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhibit2 : Exhibit
{
    [SerializeField]
    Transform carSpawnLocation, animalSpawn;
    [SerializeField]
    KinematicCar carPrefab;
    [SerializeField]
    GameObject animalPrefab;
    [SerializeField]
    float carSpeed = 20f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarSpawn()
    {
        KinematicCar car = Instantiate(carPrefab, carSpawnLocation.position, Quaternion.Euler(0, 180, 0));
        //according to how we've used rigid bodies before, we should just be able to set the car's velocity and have it move, so let's try that
        //the car moves in the direction of (0, 0, -carSpeed); (it is moving in the z direction)
        car.SetMove(new Vector3(0, 0, -carSpeed));
        //car.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -carSpeed); //this is how we did this before for dynamic rigid bodies. However, for Kinematic rigid bodies, we can't set a velocity. Oh no.
    }
    public void SheepSpawn()
    {
        GameObject animal = Instantiate(animalPrefab, animalSpawn.position, Quaternion.identity);
    }

}
