using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 startPosition;  // store original spawn position
    private Rigidbody rb;

    void Start()
    {
        // Save the player's starting position
        startPosition = transform.position;

        // Cache Rigidbody (if the player has one)
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deathbed"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Reset position
        transform.position = startPosition;

        // Reset velocity if using Rigidbody
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
