using UnityEngine;
using UnityEngine.InputSystem;


public class Deactivator : MonoBehaviour
{
    public float pushPower = 2f;
    public Transform player;
    public GameObject challenge; 
    public float deactivateDistance = 1f; 

    private Vector3 originalPosition;
    private Rigidbody rb;

    private void Start()
    {
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 pushDir = new Vector3(collision.transform.forward.x, 0, collision.transform.forward.z);
            rb.linearVelocity = pushDir * pushPower;
        }
    }

    private void FixedUpdate()
    {
        float movedDistance = Vector3.Distance(originalPosition, transform.position);
        if (movedDistance >= deactivateDistance && challenge != null)
        {
            challenge.SetActive(false);
        }
    }
}
