using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackEnd : MonoBehaviour
{
    private MeshCollider myCollider;
    // Start is called before the first frame update
    void Start()
    {
        //  gameObject.tag = "Finish";
        myCollider = GetComponent<MeshCollider>();
        myCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
