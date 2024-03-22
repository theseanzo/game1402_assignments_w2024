using System.Collections;
using System.Collections.Generic;
using System.Net;
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
	

	//NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
	public void Spawn() 
	{
		if (currentAnimal == null) // what am I even doing here
		{
            Vector3 direction = (endLocation.position - spawnLocation.position).normalized;
            A2Animal newAnimal = Instantiate(animal, spawnLocation.position, Quaternion.Euler(0, 90, 0)); //here's the goat
            newAnimal.animalDirection = direction; //send it the right way
            newAnimal.animalDestination = endLocation.position;
            currentAnimal = newAnimal;
        }
	}
}
