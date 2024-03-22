using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class FrictionGoat : A2Animal
{
    #region Sean code do not touch

    #endregion

    A2Animal fGoat;
    TrackEnd trackEnd;
    [SerializeField]
    float distance;
    

    public void Start()
    {

        fGoat = FindObjectOfType<FrictionGoat>();
        speed = 0.5f;
        trackEnd = FindObjectOfType<TrackEnd>();
        end = trackEnd.transform;
        animalTransform = fGoat.transform;

    }
    private void Update()
    {
        #region Sean Code Do Not Touch
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Move();
            Debug.Log("move");
        }

        if (fGoat != null)
        {
            distance = Vector3.Distance(fGoat.transform.position, end.position);
            Debug.Log("Distance between objects: " + distance);
        }

        if (distance <= 1.5f)
        {
            Destroy(this.gameObject);
        }
    }
       


        #endregion


}
