using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public string keyName;
    public bool isKey = true;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PickUp(Transform holdpoint, PlayerKeyInventory inventory)
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        transform.position = holdpoint.position;
        transform.parent = holdpoint;

        if (isKey && inventory != null && !string.IsNullOrEmpty(keyName))
        {
            inventory.AddKey(keyName);
            //Destroy(gameObject, 0.1f);
        }
    }

    public void Drop()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        transform.parent = null;
    }

    public void MoveToHoldPoint(Vector3 targetPosition)
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 15f);
    }

    public void MoveToInspect(Vector3 targetPosition)
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
    }

    public void RotateHeld(Vector2 input)
    {
        float rotateSpeed = 100f;
        transform.Rotate(Vector3.up, -input.x * rotateSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right, input.y * rotateSpeed * Time.deltaTime, Space.World);
    }
}




