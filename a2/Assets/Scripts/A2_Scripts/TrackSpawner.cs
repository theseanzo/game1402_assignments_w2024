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

	bool _animalOnTrack;

	float _distanceUntilEnd;

    private void FixedUpdate()
    {
        if (currentAnimal != null)
        {
            _distanceUntilEnd = Vector3.Distance(currentAnimal.transform.position, endLocation.position);
			Despawn();
        }
		else
		{
			_animalOnTrack = false;
		}
    }

    //NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
    public void Spawn() 
	{
		if(!_animalOnTrack)
		{
            _animalOnTrack = true;
            currentAnimal = Instantiate(animal, spawnLocation.position, Quaternion.Euler(0, 90, 0));
        }
	}

	void Despawn()
	{
		if(_distanceUntilEnd < 0.5f)
		{
			Destroy(currentAnimal.gameObject);
			//currentAnimal = null;
			_animalOnTrack = false;
		}
	}
}
