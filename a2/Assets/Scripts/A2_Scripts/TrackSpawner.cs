using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    #region Sean Code Do Not Touch
    [SerializeField]
    public Transform spawnLocation, endLocation;
    [SerializeField]
    A2Animal animal;
    A2Animal currentAnimal;

    private float destroyThreshold = 1f;

    #endregion


    public void Update()
    {
        if (currentAnimal != null)
        {
            float distanceToEndpoint = Vector3.Distance(currentAnimal.transform.position, endLocation.position);

            if (distanceToEndpoint <= destroyThreshold)
            {
                Destroy(currentAnimal.gameObject);
                currentAnimal = null;
            }
        }
    }

        //NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
        public void Spawn()
        {
            if (currentAnimal == null && animal != null && spawnLocation != null && endLocation != null)
            {
                currentAnimal = Instantiate(animal, spawnLocation.position, Quaternion.identity);
                currentAnimal.transform.LookAt(endLocation);
            }
        }
    

}