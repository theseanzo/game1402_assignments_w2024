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

	[SerializeField]
	private float _distanceCheck = 0.1f;
	//NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
	public void Spawn() 
	{
		// Spawn an animal at the spawn location as a child of this track
		// Set the animal's onReachTrackEndDelegate to Despawn
		currentAnimal = Instantiate(animal, spawnLocation.position, Quaternion.Euler(0, 90, 0), this.transform);
		currentAnimal.onReachTrackEndDelegate += Despawn;
	}

	private void Update()
	{
		if(currentAnimal != null)
		{
			IsAnimalAtTrackEnd();
		}
	}

	// Check if the animal is at the end of the track
	// Only do this check if the animal is kinematic
	public void IsAnimalAtTrackEnd()
	{
		if(currentAnimal.IsKinematic() && Vector3.Distance(currentAnimal.transform.position, endLocation.position) < _distanceCheck)
		{
			Despawn();
		}
	}

	public bool CanSpawn()
	{
		return currentAnimal == null;
	}

	private void Despawn()
	{
		Destroy(currentAnimal.gameObject);
		currentAnimal = null;
	}
}
