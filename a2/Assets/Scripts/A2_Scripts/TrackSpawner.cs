using System.Collections;
using System.Collections.Generic;
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

	bool isAnimalOnTrack; 
    private void FixedUpdate()
    {
        if (currentAnimal != null)
		{
			float distanceFromEnd = Vector3.Distance(currentAnimal.transform.position, endLocation.position);
			if (distanceFromEnd < 0.5f)
			{
				Disappear();
			}
		}
		else
		{
			if (!isAnimalOnTrack)
			{
				isAnimalOnTrack = false; 
			}
			else
			{
				isAnimalOnTrack = true;
			}
		}
    }

    //NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
    public void Spawn() 
	{
		if (! isAnimalOnTrack)
		{
			isAnimalOnTrack = true;
			currentAnimal = Instantiate(animal, spawnLocation.position, Quaternion.Euler(0, 90, 0)); 
		}
	}

	private void Disappear()
	{
		if (currentAnimal != null && isAnimalOnTrack == true)
		{
			Destroy(currentAnimal);
			currentAnimal = null; 
			isAnimalOnTrack = false;
		}	
	}

}
