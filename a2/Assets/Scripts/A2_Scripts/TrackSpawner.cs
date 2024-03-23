using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class TrackSpawner : MonoBehaviour
{
	/// <summary>
	/// Manages the spawning and lifecycle of animals on a track.
	/// </summary>
	
    #region Sean Code Do Not Touch
    [SerializeField]
	public Transform spawnLocation, endLocation;
	[SerializeField]
	A2Animal animal;
	A2Animal currentAnimal;
    #endregion
    
	public void Spawn() 
	{
		if (currentAnimal == null && animal != null && spawnLocation != null)
		{
			currentAnimal = Instantiate(animal, spawnLocation.position, Quaternion.identity);
			if (endLocation != null)
			{
				currentAnimal.transform.LookAt(endLocation.position);
			}
		}
	}
}
