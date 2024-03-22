using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrackSpawner : MonoBehaviour
{
    #region Sean Code Do Not Touch
    [SerializeField]
	Transform spawnLocation, endLocation;
	[SerializeField]
	A2Animal animal;
	A2Animal currentAnimal;
    #endregion
    
    public Transform endPos = endLocation.position.x;
    public Transform spawnPos = spawnLocation.position.x;

    //NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
    public void Spawn() 
	{

        while (currentAnimal == null)
        {
            currentAnimal = Instantiate(animal,spawnLocation.position, Quaternion.Euler(0, 90, 0)); //create a new sheep according to the spawn location and rotating it 90 degrees
            
            currentAnimal.Move();


            if (currentAnimal.transform.position == endLocation.position)
            {
                Destroy(this.gameObject);
                Spawn();
            }
        }
    }
}
