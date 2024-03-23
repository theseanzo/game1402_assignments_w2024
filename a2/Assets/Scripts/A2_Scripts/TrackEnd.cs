using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackEnd : MonoBehaviour
{
    MeshCollider mesh;
    BoxCollider box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Awake()
    {
        mesh = GetComponent<MeshCollider>();
        mesh.enabled = true;
        mesh.convex = true;
        mesh.isTrigger = true;
    }
}
