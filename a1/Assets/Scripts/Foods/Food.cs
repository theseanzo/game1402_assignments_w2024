using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    bool hit = false;
    public int Value { get; protected set; }

    void Awake()
    {
        // Set the food value to the base food value
        Value = GameConstants.BaseFoodValue;
    }

    //OnTriggerEnter is called when the Collider other enters the trigger.
    //This function is called when the GameObject collides with another GameObject
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && !hit)
        {
            hit = true;
            GameManager.Instance.Score += Value;
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        // Check if the food object is already inactive
        if (!gameObject.activeSelf)
        {
            // Activate the food object
            gameObject.SetActive(true);
        }

        // Reset the hit flag to allow the player to collect it again
        hit = false;

        // Get the renderer of the food object
        Renderer renderer = GetComponent<Renderer>();

        // Gradually increase the metallic value to fade in the food object
        float metallic = 0f;
        while (metallic < 1f)
        {
            metallic += Time.deltaTime; // Adjust the speed of the fade-in effect here
            renderer.material.SetFloat("_Metallic", metallic);
            yield return null;
        }

        // Deactivate the food object
        gameObject.SetActive(false);

        // Notify GameManager to respawn the food after a certain time
        GameManager.Instance.RespawnFood(this);
    }
}
