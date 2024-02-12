using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private float respawnTimerDefault = 1f;
    MeshRenderer meshRenderer;
    Coroutine respawn;
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
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && !hit)
        {
            hit = true;
            GameManager.Instance.Score += Value; //recall that the value is set in each one of the food's children
            respawn = StartCoroutine(RespawnFood());
        }
        
    }

    IEnumerator RespawnFood()
    {
        float respawnTimer = respawnTimerDefault;                       //setup new separate variable respawn timer
        GetComponent<BoxCollider>().enabled = false;                    //disable pickup hitbox
        hit = false;                                                    //boolean switch
        Color color = meshRenderer.material.color;                      //set up reference to material
        color.a = 0.0f;                                                 //set alpha to 0
        while (respawnTimer > 0)
            {
            color.a = color.a + (2.0f / (respawnTimerDefault * 100f));  //increment alpha by a number based on how long the respawn timer lasts
            meshRenderer.material.color = color;                        //set material alpha to new alpha value
            respawnTimer = respawnTimer - Time.deltaTime;               //decrement timer
            yield return new WaitForFixedUpdate();                      //wait for fixedupdate
            if(respawnTimer <= 0.01f)                                   //check if timer has finished
            {
                respawnTimer = respawnTimerDefault;                     //just to be safe, set timer back to default
                color.a = 1.0f;                                         //...and the alpha as well
                GetComponent<BoxCollider>().enabled = true;             //re-enable collider
                StopCoroutine(respawn);
            }
        }
    }
}
