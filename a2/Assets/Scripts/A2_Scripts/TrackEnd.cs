using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackEnd : MonoBehaviour
{
    MeshCollider _mc;
    // Start is called before the first frame update
    void Awake()
    {
        _mc = GetComponent<MeshCollider>();
        _mc.convex = true;
        _mc.enabled = true; //This sent me on a wild goose chase of thinking my triggers/collisions weren't working because the first TrackEnd does not have this enabled by default. I am very sad.
        _mc.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
