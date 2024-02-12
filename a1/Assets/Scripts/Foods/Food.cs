using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    float FoodRespawnTime = 5;//wont show in the editor?
    private Transform foods;
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

    IEnumerator WaitSecs()
    {
       
        transform.Translate(0, -10, 0);// wanted to used SetActive and a food manager but owen suggested i use this simple movment script instead 
        yield return new WaitForSeconds(FoodRespawnTime);
        transform.Translate(0, 10, 0);
        yield return new WaitForSeconds(2);//wait so player cant pickup food instantly
        hit = false;
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && !hit)
        {
            
            hit = true;
            GameManager.Instance.Score += Value; //recall that the value is set in each one of the food's children
            foods = this.transform;// sets food location
            StartCoroutine(WaitSecs());



        }
        
    }
}
