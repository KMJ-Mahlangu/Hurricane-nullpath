using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private Rigidbody rb;
    public bool isMapPiece = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PickUp(Transform holdpoint)
    {
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.SetParent(holdpoint);
        transform.localPosition = Vector3.zero;

        if(isMapPiece)
        {
            MapManager.Instance.CollectPiece();
           
            Destroy(gameObject);
           
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
