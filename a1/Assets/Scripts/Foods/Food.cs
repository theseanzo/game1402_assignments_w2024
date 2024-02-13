using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int spawnTime = 5;
    
    bool hit = false;
    public int Value
    

    {
        get; protected set;
    }
    void Awake()
    {
        Collider foodCollider = GetComponent<Collider>();
        foodCollider.isTrigger = true;
        Value = GameConstants.BaseFoodValue;
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
        if (other.gameObject.GetComponent<PlayerController>() && !hit)
        {
            hit = true;
            GameManager.Instance.Score += Value; //recall that the value is set in each one of the food's children
                                                //GetComponent<Collider>().enabled = false; I WAS PLANNING TO USE Collider.enable=false, BUT I COULD GET IT TO WORK USING COROUTINE, SO OUT OF CURIOSITY I TRIED PLAYING HIT =TRUE & FALSE AND SURPRINSINGLY, IT WORKED.
            transform.localScale = new Vector3(0, 0, 0);
            StartCoroutine(FoodRespawn());
            

        }

        

    }
    IEnumerator FoodRespawn()
    {
        Vector3 initialScale = transform.localScale;
        Vector3 finalScale = transform.localScale + new Vector3(3.0f, 3.0f, 3.0f);
        float elapsedTime = -5f;
        float spawnTime = 5f;
        
        while (elapsedTime < spawnTime)
        { 
            transform.localScale = Vector3.Lerp (initialScale,finalScale, (elapsedTime / spawnTime));
            elapsedTime += Time.deltaTime;

            yield return null;
            
        }
        transform.localScale = finalScale;
        hit = false; // AFTER EXPERIMENTING, AND TRYING TO PUT HIT= FALSE THROUGH OUT THE ENTIRE CODE, I REALIZED THE LOGICAL MOVE WAS TO PUT IT AT THE END OF THE COROUTINE, TO MY SURPRISED IT ACTUALLY WORKED, NOW THE FOOD CANNOT BE GRABBABLE WHILST "SPAWNING" AND                  GRABBABLE WHEN ITS AT FULL SIZE
    
    }

}
