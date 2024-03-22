using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhibit3_A2 : Exhibit
{
	[SerializeField]
	TrackSpawner[] trackSpawners;
	// Update is called once per frame
	private GameObject[] activeAnimals;

	void Start()
	{
		activeAnimals = new GameObject[trackSpawners.Length];
	}
	
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
		for (int i = 0; i < trackSpawners.Length; i++)
		{
			trackSpawners[i].Spawn();
		}
	}
}
