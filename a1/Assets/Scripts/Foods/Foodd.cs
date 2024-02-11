using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Foodd : MonoBehaviour
{

    public static Foodd instance;
    public bool hit = false;

     [SerializeField]
     float waitTime;
    [SerializeField]
    float speed =1.0f;
    private UnityEngine.Vector3 target;

    private UnityEngine.Vector3 startPosition;

    bool grabable = true;
    public int Value
    {
        get; protected set;
    }
    void Awake()
    {
        Collider foodCollider = GetComponent<Collider>();
        foodCollider.isTrigger = true;
        Value = GameConstants.BaseFoodValue;    
        startPosition = gameObject.transform.position;
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
         if (other.gameObject.GetComponent<PlayerController>() && !hit && grabable)
         {
            GameManager.Instance.Score += Value; //recall that the value is set in each one of the food's children
            hit = true;
            grabable = false;//make food not grabbable with a bool statment during the duration of the coroutine 
            transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
            StartCoroutine(CountDown());
            StartCoroutine(Respawn());


         }
    
    }

    public IEnumerator Respawn()
    {

        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        
        while (true)
        {
        transform.position = UnityEngine.Vector3.Lerp(transform.position, startPosition, 1.0f * Time.fixedDeltaTime);
        yield return new WaitForFixedUpdate();// move food above and bellow the map using a coroutine and some linerar interpolation logic (thanks owen)
        }
        

    } 
    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(waitTime);  
        hit = false;
        grabable = true;
        
        
    }

}
