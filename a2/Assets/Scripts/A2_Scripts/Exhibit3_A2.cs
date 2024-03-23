using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhibit3_A2 : Exhibit
{
	[SerializeField]
	TrackSpawner[] trackSpawners;

	void Start()
	{
        
    }

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

    public void StartSpawning()
	{
		foreach (TrackSpawner tracks in trackSpawners)
		{
			tracks.Spawn(); //creates a loop that spawns an animal in each track
		}
	}
}
