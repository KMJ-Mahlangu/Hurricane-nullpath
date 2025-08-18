using UnityEngine;

public class SimpleSlideGate : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("How fast the gate opens")]
    [SerializeField] private float openSpeed = 3f;
    
    [Tooltip("How far the gate moves (in meters)")]
    [SerializeField] private float slideDistance = 2f;
    
    [Tooltip("Direction to slide (right = positive X)")]
    [SerializeField] private bool slideRight = true;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;
    private bool isOpen = false;
    private Collider gateCollider;

    private void Start()
    {
        gateCollider = GetComponent<Collider>();
        closedPosition = transform.position;
        openPosition = closedPosition + (slideRight ? Vector3.right : Vector3.left) * slideDistance;
    }

    private void Update()
    {
        if (isOpening && !isOpen)
        {
            // Move the gate smoothly
            transform.position = Vector3.MoveTowards(transform.position, openPosition, openSpeed * Time.deltaTime);
            
            // Check if fully open
            if (Vector3.Distance(transform.position, openPosition) < 0.01f)
            {
                isOpen = true;
                gateCollider.enabled = false; // Disable collision when fully open
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpening)
        {
            isOpening = true;
        }
    }

    // Visual helper in editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 direction = slideRight ? Vector3.right : Vector3.left;
        Gizmos.DrawLine(transform.position, transform.position + direction * slideDistance);
        Gizmos.DrawWireCube(transform.position + direction * slideDistance, transform.localScale);
    }
}