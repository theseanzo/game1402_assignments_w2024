using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    #region Sean Code Do Not Touch
    [SerializeField]
	Transform spawnLocation, endLocation;
	[SerializeField]
	A2Animal animal;
	A2Animal currentAnimal;
    #endregion

    //public Vector3 movement;
    public float distance; //creating a float variable to gather the distance, which will be described in the code

    //NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
    public void Spawn() 
	{
        if (currentAnimal == null) //if there isn't an animal in the scene, you can create a new sheep
            currentAnimal = Instantiate(animal, spawnLocation.position, Quaternion.Euler(0, 90, 0));
        //new sheep created according to the spawn location and rotating it 90 degrees
    }

    public void Update()
    {

        if (currentAnimal != null)
        {
            distance = Vector3.Distance(spawnLocation.position, endLocation.position); //if there is an animal in the scene, it can be moved forward in the space between the spawn location and end location

            //currentAnimal.Move();
        }

        if (distance <= 1f)
        {
            Destroy(currentAnimal); //if the player is close to the end, destroy the animal 
            //Spawn();
        }

    }
}
