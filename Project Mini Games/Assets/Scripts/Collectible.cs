using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 10; // Score value of the collectible

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player (or any other object with a specific tag) has entered the trigger zone
        if (other.CompareTag("Player"))
        {
            // You can add sound effects, particle effects, or any other collectible-related behavior here

            // Call a method to handle the collection (e.g., increase score)
            Collect();
        }
    }

    void Collect()
    {
        GameManager.instance.CollectItem(); // Notify GameManager that an item is collected
        Debug.Log("Item Collected!");
        // Optionally, play a collectible sound or particle effect
        // AudioSource.PlayClipAtPoint(collectSound, transform.position);

        // Destroy the collectible object
        Destroy(gameObject);
    }
}

