using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float swipeTurnSpeed = 2f;

    void Update()
    {
        // Constant forward movement
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Swipe-based turning
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check for swipe
            if (touch.phase == TouchPhase.Moved)
            {
                // Calculate swipe direction in world space
                Vector3 swipeDirection = new Vector3(touch.deltaPosition.x, 0f, touch.deltaPosition.y).normalized;

                // Rotate the player based on swipe direction
                Vector3 newForward = Vector3.RotateTowards(transform.forward, swipeDirection, swipeTurnSpeed * Time.deltaTime, 0f);
                transform.rotation = Quaternion.LookRotation(newForward);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the obstacle
        if (other.CompareTag("Obstacle"))
        {
            // Stop forward movement
            forwardSpeed = 0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Resume forward movement when the player moves away from the obstacle
        if (other.CompareTag("Obstacle"))
        {
            forwardSpeed = 5f; // Adjust the speed as needed
        }
    }

}

