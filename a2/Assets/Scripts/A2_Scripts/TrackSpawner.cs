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
	float distance;
    //NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
    public void Spawn() 
	{
		currentAnimal = Instantiate(animal, spawnLocation.position, Quaternion.Euler(0,90,0));
	}
	public void Update()
	{
		if (currentAnimal == null)
		{

			if (Input.GetKeyDown(KeyCode.E))
				Spawn();



			
		}
		if (currentAnimal != null)
		{
            distance = Vector3.Distance(currentAnimal.transform.position, endLocation.position);
            if (distance <= 1f)
            {

                Destroy(currentAnimal.gameObject);
            }

        }

    }

}
