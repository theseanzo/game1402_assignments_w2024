using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhibit3_A2 : Exhibit
{
	[SerializeField]
	TrackSpawner[] trackSpawners;
	// Update is called once per frame
	void Update()
	{
		#region SEAN CODE DO NOT TOUCH
		if (Input.GetKeyDown(KeyCode.E))
		{
			StartSpawning();
		}
        #endregion
    }

	// Loop through all the track spawners and spawn an animal if it can
    public void StartSpawning()
	{
		foreach(TrackSpawner trackSpawner in trackSpawners)
		{
			if(trackSpawner.CanSpawn())
			{
				trackSpawner.Spawn();
			}
		}
	}
}
