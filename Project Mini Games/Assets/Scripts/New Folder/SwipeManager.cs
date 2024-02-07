using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public ParticleSystem swipeParticle; // Reference to the Particle System
    private CinemachineVirtualCamera virtualCamera;
    public LayerMask playerLayer;

    private void Start()
    {
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse button up");

            // Use Cinemachine's ScreenToWorldPoint to convert mouse position to world space
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Perform the raycast using Cinemachine's raycasting method
            RaycastHit hit;
            if (Physics.Raycast(touchPosition, virtualCamera.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, playerLayer))
            {
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    TriggerSwipeParticle(hit.transform);
                }
            }
        }
    }
   
    
    void TriggerSwipeParticle(Transform playerTransform)
    {
        Debug.Log("Triggering particle system");

        // Set the position of the particle system to the player's back position
        Vector3 particlePosition = playerTransform.position - playerTransform.forward * 0.5f;
        swipeParticle.transform.position = particlePosition;

        // Play the Particle System
        swipeParticle.Play();
    }
}



