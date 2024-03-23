using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    #region Sean Code Do Not Touch
    [SerializeField]
	public Transform spawnLocation, endLocation;
	[SerializeField]
	
	
	A2Animal animal;
	A2Animal currentAnimal;
	
    #endregion

    public void Update()
    {
	    //if (currentAnimal != false) 

	    if (currentAnimal)
	    {
		    float distance = Vector3.Distance(currentAnimal.transform.position, endLocation.position);
                
		    if (distance <= 1f)
		    {
			    Destroy(currentAnimal.gameObject);
		    }
	    }

	    
    }

    //NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
	public void Spawn() 
	{
		if (currentAnimal == null)
		{
			currentAnimal = Instantiate(animal, spawnLocation.position,
						Quaternion.Euler(0,90,0));
		}
		
	}
	
	
	
}
