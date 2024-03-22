using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackEnd : MonoBehaviour
{
    private void Awake()
    {
        MeshCollider _meshCollider = gameObject.GetComponent<MeshCollider>();
        _meshCollider.enabled = true;
        _meshCollider.convex = true;
        _meshCollider.isTrigger = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
