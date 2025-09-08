using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private Rigidbody rb;
    private bool isKey = false;
    [SerializeField] private bool showDebugMessages = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isKey = CompareTag("Key");
    }

    public void PickUp(Transform holdpoint)
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        transform.position = holdpoint.position;
        transform.parent = holdpoint;
       /*rb.linearVelocity = Vector3.zero;
       rb.angularVelocity = Vector3.zero;
        transform.SetParent(holdpoint);
        transform.localPosition = Vector3.zero;*/

        if (isKey)
        {
            PlayerKeyInventory inventory = holdpoint.root.GetComponent<PlayerKeyInventory>();
            if (inventory != null)
            {
                inventory.AddKey();
                if (showDebugMessages) Debug.Log("Key added to inventory", this);
               // Destroy(gameObject, 0.1f);
            }
        }
    }

    public void Drop()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        transform.parent = null;
        //transform.SetParent(null);
    }

    public void MoveToHoldPoint(Vector3 targetPosition)
    {
       // rb.MovePosition(targetPosition);
       transform.position = Vector3.Lerp(transform.position, targetPosition,Time.deltaTime*15f);

    }
}