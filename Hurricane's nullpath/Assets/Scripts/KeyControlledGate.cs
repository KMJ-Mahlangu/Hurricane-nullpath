using UnityEngine;

public class KeyControlledGate : MonoBehaviour
{
    [Header("Gate Settings")]
    [SerializeField] private float openSpeed = 3f;
    [SerializeField] private float slideDistance = 2f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;
    private bool isOpen = false;
    private Collider gateCollider;

    private void Start()
    {
        gateCollider = GetComponent<Collider>();
        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.left * slideDistance;
    }

    private void Update()
    {
        if (isOpening && !isOpen)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                openPosition,
                openSpeed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, openPosition) < 0.01f)
            {
                isOpen = true;
                gateCollider.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpening)
        {
            PlayerKeyInventory inventory = other.GetComponent<PlayerKeyInventory>();
            if (inventory != null && inventory.HasAllKeys())
            {
                isOpening = true;
                Debug.Log("Gate opening!");
            }
            else
            {
                Debug.Log("You need all 3 keys to open this gate!");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * slideDistance);
        Gizmos.DrawWireCube(transform.position + Vector3.left * slideDistance, transform.localScale);
    }
}