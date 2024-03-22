using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
		currentAnimal = Instantiate(animal, spawnLocation.position, Quaternion.Euler(0,90,0));
	}
	public bool IsAnimalPresent()
	{
		return currentAnimal != null;
	}
	void Update()
	{
		if(currentAnimal!= null && Vector3.Distance(currentAnimal.transform.position, endLocation.position)< 0.1f)
		{
			Destroy(currentAnimal.gameObject);
			currentAnimal = null;
		}
	}
}
