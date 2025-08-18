using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private Rigidbody rb;
    private bool isKey = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isKey = CompareTag("Key"); // Tag your key objects with "Key"
    }

    public void PickUp(Transform holdpoint)
    {
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.SetParent(holdpoint);
        transform.localPosition = Vector3.zero;

        if (isKey)
        {
            PlayerKeyInventory inventory = holdpoint.root.GetComponent<PlayerKeyInventory>();
            if (inventory != null)
            {
                inventory.AddKey();
                Destroy(gameObject, 0.1f); // Destroy the key after a small delay
            }
        }
    }

    public void Drop()
    {
        rb.useGravity = true;
        transform.SetParent(null);
    }

    public void MoveToHoldPoint(Vector3 targetPosition)
    {
        rb.MovePosition(targetPosition);
    }
}