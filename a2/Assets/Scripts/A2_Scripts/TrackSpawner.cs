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
    public float distance;

    //NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
    public void Spawn() 
	{
        if (currentAnimal == null)
            currentAnimal = Instantiate(animal, spawnLocation.position, Quaternion.Euler(0, 90, 0));
        //create a new sheep
        //according to the spawn location and rotating it 90 degrees
    }

    public void Update()
    {

        if (currentAnimal != null)
        {
            distance = Vector3.Distance(spawnLocation.position, endLocation.position);

            //currentAnimal.Move();
        }

/*        if (distance <= 1f)
        {
                Destroy(currentAnimal);
                //Spawn();
        }
*/        
    }
}
