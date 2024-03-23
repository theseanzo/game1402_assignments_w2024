using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhibit3_A2 : Exhibit
{
	[SerializeField]
	TrackSpawner[] trackSpawners;
	TrackSpawner _spawnerRef;

	void Start()
	{
        _spawnerRef = FindObjectOfType<TrackSpawner>();
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
			tracks.Spawn();
		}
	}
}
