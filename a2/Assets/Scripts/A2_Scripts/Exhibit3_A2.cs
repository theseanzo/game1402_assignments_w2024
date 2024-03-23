using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhibit3_A2 : Exhibit
{
	[SerializeField]
	TrackSpawner[] trackSpawners;
    private void Start()
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
		for(int i = 0; i < trackSpawners.Length; i++)
		{
			trackSpawners[i].Spawn();
		}
	}
}
