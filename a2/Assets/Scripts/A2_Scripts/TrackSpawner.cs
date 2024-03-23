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

	//NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
	public void Spawn()
	{
        if (currentAnimal == null)
		{
			currentAnimal = Instantiate(animal, spawnLocation.position, spawnLocation.rotation) as A2Animal;
			currentAnimal.transform.Rotate(-90, 90, 0);
		}
	}

	public bool HasCurrentAnimal()
	{
		return currentAnimal != null;
	}
    public void Awake()
    {
		//gameObject.tag = "Finish";
		//I tried using this but it didn't seem to work as well as just checking object name...
    }
}
