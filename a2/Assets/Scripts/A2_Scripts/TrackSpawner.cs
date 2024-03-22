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
	public Transform trueEndLocation;
    //NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
    private void Awake()
    {
		trueEndLocation = endLocation;
    }
    public void Spawn() 
	{
		Instantiate(animal, spawnLocation.position, Quaternion.Euler(0,90,0));
	}
}
