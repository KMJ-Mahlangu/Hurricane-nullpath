using UnityEngine;
using System.Collections;

public class EnemyKillPlayer : MonoBehaviour
{
    public string playerTag = "Player";
    public int maxLives = 3;
    public float respawnDelay = 1.5f;

    private int playerLives = 0;
    private bool isRespawning = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            HandlePlayerHit(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            HandlePlayerHit(other.gameObject);
        }
    }

    void HandlePlayerHit(GameObject character)
    {
        if (isRespawning) return;

        playerLives++;

        if (playerLives < maxLives)
        {
            // Store last position before killing
            Vector3 lastPosition = character.transform.position;

            Debug.Log($"Player died! Respawning at last position... Lives used: {playerLives}/{maxLives}");
            StartCoroutine(RespawnSequence(character, lastPosition));
        }
        else
        {
            Debug.Log("Player has no more lives. Game Over!");
            Destroy(character); // Instantly destroy player on last life
        }
    }

    IEnumerator RespawnSequence(GameObject character, Vector3 lastPosition)
    {
        isRespawning = true;

        // Disable movement (if using a movement script)
        MonoBehaviour movement = character.GetComponent<MonoBehaviour>();
        if (movement != null) movement.enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        // Teleport player to last position
        character.transform.position = lastPosition;

        // Reset Rigidbody velocity if it exists
        Rigidbody rb = character.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Re-enable movement
        if (movement != null) movement.enabled = true;

        isRespawning = false;
    }
}
