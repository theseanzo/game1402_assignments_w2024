using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public float distance;

    //NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
    public void Spawn()
    {

        if (currentAnimal == null)
        {
            currentAnimal = Instantiate(animal, spawnLocation.position,
                        Quaternion.Euler(0,90,0));



        }
    }
}
