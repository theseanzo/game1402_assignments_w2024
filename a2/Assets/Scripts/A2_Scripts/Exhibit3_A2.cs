using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhibit3_A2 : Exhibit
{
	[SerializeField]
	TrackSpawner[] trackSpawners;	// Update is called once per frame
	void Update()
	{
		#region SEAN CODE DO NOT TOUCH
		if (Input.GetKeyDown(KeyCode.E))
		{
			StartSpawning();
		}
        #endregion
    }

    public void StartSpawning()
	{
		if (!AnimalsExist())
		{
			foreach (TrackSpawner spawner in trackSpawners)
			{
				spawner.Spawn();
			}
		}
		else
			Debug.Log("No more animals can be spawned at this time.");
    }
	private bool AnimalsExist()
	{
		int animals = FindObjectsOfType<A2Animal>().Length;
		if (animals > 0)
			return true;
		else 
			return false;
	}
}
