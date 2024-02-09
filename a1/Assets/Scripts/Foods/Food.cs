using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    bool hit = false;
    bool grabbable;

    float _collectOffset = 1f;
    public int Value
    {
        get; protected set;
    }

    Vector3 startPosition;

    void Awake()
    {
        Collider foodCollider = GetComponent<Collider>();
        foodCollider.isTrigger = true;
        Value = GameConstants.BaseFoodValue;
        grabbable = true;
        startPosition = transform.position;
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
        if (other.gameObject.GetComponent<PlayerController>() && !hit && grabbable)
        {
            hit = true;
            grabbable = false;
            GameManager.Instance.Score += Value; //recall that the value is set in each one of the food's children

            //Making it so that upon colliding with the player, the food will fall beneath the floor, then slowly rising back up above the surface.
            
            transform.position = new Vector3(transform.position.x, transform.position.y - _collectOffset, transform.position.z);
            StartCoroutine(StartFoodSpawnerCountDown());
            StartCoroutine(SmoothlyUnhideCollectible());
        }
        
    }

    //Starts the timer to handle interactiveness
    IEnumerator StartFoodSpawnerCountDown()
    {
        yield return new WaitForSeconds(5f);
        grabbable = true;
        hit = false;
    }

    //Slowly moves the position of the food back to it's original position;
    IEnumerator SmoothlyUnhideCollectible()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, startPosition, 0.25f * Time.fixedDeltaTime);

            yield return new WaitForFixedUpdate();
        }
    }
}
