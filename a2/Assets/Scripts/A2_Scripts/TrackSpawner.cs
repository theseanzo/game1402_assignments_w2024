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

	bool _isAnimalSpawned = false;
	float _endDistance;

	//NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
	public void Spawn() 
	{
		if (!_isAnimalSpawned)
		{
			_isAnimalSpawned = true;
			currentAnimal = Instantiate(animal, spawnLocation.position, Quaternion.Euler(animal.transform.rotation.x, 90f, transform.rotation.z));
		}
	}

	void FixedUpdate()
	{
		if (currentAnimal == null)
		{
			_isAnimalSpawned = false;
		}
		else
		{
			_endDistance = Vector3.Distance(currentAnimal.transform.position, endLocation.position);
			DestroyAnimal();
		}
	}

	// Destroys animals on within range of the end point
	void DestroyAnimal()
	{
		if (_endDistance < 0.5f)
		{
			Destroy(currentAnimal.gameObject);
			_isAnimalSpawned = false;
		}
	}
}
