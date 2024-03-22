using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhibit3_A2 : Exhibit
{
	[SerializeField]
	TrackSpawner[] trackSpawners;
	void Update()
	{
		#region SEAN CODE DO NOT TOUCH
		if (Input.GetKeyDown(KeyCode.E))
		{
			StartSpawning();
		}
        #endregion
    }

    private void StartSpawning()
    {
        foreach (var spawner in trackSpawners)
        {
            if (!spawner.AnimalOnTrack())
            {
                spawner.Spawn();
            }
            else
            {
                Debug.Log("Animal already exists on the track.");
            }
        }
    }
}
