using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrackSpawner : MonoBehaviour
{
    #region Sean Code Do Not Touch
    [SerializeField]
	Transform spawnLocation, endLocation;
	[SerializeField]
	A2Animal animal;
	A2Animal currentAnimal;
    #endregion

    ShiftSheep _shift;

    public Vector3 movement;

    public void Start()
    {
        _shift = GetComponent<ShiftSheep>();
    }

    //NOTE: Every A2 Animal, when spawned, will need to be rotated 90 on the y axis
    public void Spawn() 
	{
        currentAnimal = Instantiate(animal, spawnLocation.position, Quaternion.Euler(0, 90, 0)); //create a new sheep according to the spawn location and rotating it 90 degrees
    }

    public void Update()
    {
        if (currentAnimal == null)
        {
            Spawn();

            if (currentAnimal._canMove == true)
            {
                movement = (endLocation.position - spawnLocation.position).normalized;
                currentAnimal.transform.position = movement;
                currentAnimal.Move();
            }

            else if (currentAnimal == _shift)
            {
                currentAnimal.transform.position = Vector3.MoveTowards(currentAnimal.transform.position, movement, _shift.distance);
            }

            if (currentAnimal.transform.position == endLocation.position)
            {
                Destroy(this.gameObject);
                Spawn();
            }
        }
    }
}
