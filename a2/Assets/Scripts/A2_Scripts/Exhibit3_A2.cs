using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Exhibit3_A2 : Exhibit
{
	[SerializeField] //Ended up not getting this to work properly, did code in trackspawner instead.
    TrackSpawner[] trackSpawners;
    private StarterAssetsInputs _input;
	private bool _isSheepSpawned;
    private bool _isGoatSpawned;
    private bool _isfGoatSpawned;
    [SerializeField]
    private GameObject Sheep;
    [SerializeField]
    private GameObject Goat;
    [SerializeField]
    private GameObject fGoat;
	[SerializeField]
	private Transform track1pos;
	[SerializeField]
	private Transform track2pos;
	[SerializeField] 
	private Transform track3pos;

    // Update is called once per frame
   /* void Update()
	{
        #region SEAN CODE DO NOT TOUCH
        if (Input.GetKeyDown(KeyCode.E))
		{
			StartSpawning();
		}
        #endregion
    }

    private void FixedUpdate()
    {
        if (Sheep == null)
        {
            _isSheepSpawned = false;
            Debug.Log("sheep");
        }
        if (Goat == null)
        {
            _isGoatSpawned = false;
        }
        if (fGoat == null)
        {
            _isfGoatSpawned = false;
            Debug.Log("goat");
        }
    }

    public void StartSpawning()
	{

        if (_isSheepSpawned == false)
        {
            GameObject instance = Instantiate(Goat, track1pos.position, track1pos.rotation);
            instance.transform.rotation = Quaternion.Euler(0, 90, 0);
            _isSheepSpawned = true;
        }

        if (_isGoatSpawned == false)
        {
            GameObject goatInstance = Instantiate(Sheep, track2pos.position, track2pos.rotation);
            goatInstance.transform.rotation = Quaternion.Euler(0, 90, 0);
            _isGoatSpawned = true;

        }
        if (_isfGoatSpawned == false)
        {
            GameObject fgoatInstance = Instantiate(fGoat, track3pos.position, track3pos.rotation);
            fgoatInstance.transform.rotation = Quaternion.Euler(0, 90, 0);
            _isfGoatSpawned = true;
        }

        
    }*/ 
   //Ended up not getting this to work properly, did code in trackspawner instead.
}
