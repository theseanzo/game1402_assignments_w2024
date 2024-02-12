using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    
    [SerializeField]
    float respawnTime = 10f; 
    [SerializeField]  
    float respawnDuration = 5f; 

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && !hit)
        {
            hit = true;
            GameManager.Instance.Score += Value; //recall that the value is set in each one of the food's children
            StartCoroutine(RespawnCoroutine());
        }
        
    }
    
    IEnumerator RespawnCoroutine()
    {
        GetComponent<Renderer>()!.enabled = false;
        GetComponent<Collider>()!.enabled = false;

        yield return new WaitForSeconds(respawnTime);

        float elapsedTime = 0;
        Renderer renderer = GetComponent<Renderer>();
        Color initialColor = renderer.material.color;
        while (elapsedTime < respawnDuration)
        {
            float alpha = elapsedTime / respawnDuration;
            renderer.material.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        renderer.material.color = new Color(initialColor.r, initialColor.g, initialColor.b, 1);

        renderer.enabled = true;
        GetComponent<Collider>().enabled = true;
        hit = false; 
    }

}
