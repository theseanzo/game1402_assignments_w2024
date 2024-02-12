using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    
    [SerializeField]
    float respawnTime = 10f; 
    [SerializeField]  
    float respawnDuration = 5f; 
    private Vector3 originalScale; 
    bool hit = false;
    [SerializeField]  
    private float rotationSpeed = 50f; // Speed of rotation

    public int Value
    {
        get; protected set;
    }
    void Awake()
    {
        Collider foodCollider = GetComponent<Collider>();
        foodCollider.isTrigger = true;
        Value = GameConstants.BaseFoodValue;
        originalScale = transform.localScale; 
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && !hit)
        {
            hit = true;
            GameManager.Instance.Score += Value; //recall that the value is set in each one of the food's children
            Renderer renderer = GetComponent<Renderer>();
            Collider collider = GetComponent<Collider>();
            renderer.enabled = false;
            collider.enabled = false;
            StartCoroutine(RespawnCoroutine());
        }
        
    }

    private IEnumerator RespawnCoroutine()
    {
        // Initially disable the renderer and collider
        Renderer renderer = GetComponent<Renderer>();
        Collider collider = GetComponent<Collider>();
  

        // Wait for the specified respawn time
        yield return new WaitForSeconds(respawnTime);
        
        renderer.enabled = true;
        // Gradually scale the item back to its original size
        float elapsedTime = 0;
        while (elapsedTime < respawnDuration)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, (elapsedTime / respawnDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the item is exactly at its original scale after the scaling process
        transform.localScale = originalScale;

        // Re-enable the collider so the item can be interacted with
        renderer.enabled = true;
        hit = false;
        collider.enabled = true;
    }

    }

