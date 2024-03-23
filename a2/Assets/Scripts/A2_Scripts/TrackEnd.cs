using UnityEngine;

public class TrackEnd : MonoBehaviour
{
    /// <summary>
    /// Executes when another collider makes contact with this object's collider. If the collider belongs to an Animal,
    /// it will be destroyed, effectively removing it from the game.
    /// </summary>
    /// <param name="other">The collider information of the object that initiated the collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is an instance of an Animal
        if (other.gameObject.CompareTag("Animal")) // Ensure your Animal objects have the tag "Animal" set in the inspector
        {
            Destroy(other.gameObject); // Removes the animal object from the scene
        }
    }
}
