using UnityEngine;

public class BubbleFloat : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float floatHeight = 0.5f;
    public float rotateSpeed = 20f;
    public Transform key; 
    public GameObject popEffectPrefab;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        if (key != null)
            key.parent = transform; 
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = startPos + new Vector3(0, y, 0);
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (popEffectPrefab != null)
                Instantiate(popEffectPrefab, transform.position, Quaternion.identity);

            if (key != null)
            {
                
                key.parent = null;

                
                Rigidbody keyRb = key.GetComponent<Rigidbody>();
                if (keyRb != null)
                {
                    keyRb.isKinematic = false;
                    keyRb.useGravity = true;
                }
            }

            Destroy(gameObject); 
        }
    }
}
