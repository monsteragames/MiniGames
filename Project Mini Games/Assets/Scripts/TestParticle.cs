using UnityEngine;

public class TestParticle : MonoBehaviour
{
    public ParticleSystem testParticle;

    void Start()
    {
        if (testParticle == null)
        {
            Debug.LogError("Test Particle not assigned!");
            return;
        }

        // Play the Particle System
        testParticle.Play();
    }
}

