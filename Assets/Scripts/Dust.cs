using UnityEngine;

public class Dust : MonoBehaviour
{
    public ParticleSystem dustParticles; // Reference to the Particle System
    public float groundCheckDistance = 0.5f; // Distance to check the ground

    private bool isGrounded;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (dustParticles == null)
        {
            Debug.LogWarning("No particle system assigned!");
        }
    }

    void FixedUpdate()
    {
        // Check if the sphere is on the ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        // Enable or disable the particle system based on grounding
        if (dustParticles != null)
        {
            if (isGrounded)
            {
                if (!dustParticles.isPlaying)
                {
                    dustParticles.Play();
                }
            }
            else
            {
                if (dustParticles.isPlaying)
                {
                    dustParticles.Stop();
                }
            }
        }
    }
}