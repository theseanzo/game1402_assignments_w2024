using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackEnd : MonoBehaviour
{
    List<GameObject> trackEndObjs = new List<GameObject> ();
    
    // Start is called before the first frame update
    void Start()
    {
        TrackEnd[] trackEnds = FindObjectsOfType<TrackEnd>();

        foreach (TrackEnd trackEnd in trackEnds)
        {
            trackEndObjs.Add(trackEnd.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    
}
