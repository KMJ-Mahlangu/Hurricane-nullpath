using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Settings for Player/Plate")]
    public Transform pointA;     
    public Transform pointB;     
    public float speed = 2f;     

    private Vector3 target;

    void Start()
    {
        target = pointB.position; 
    }

    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            collision.transform.SetParent(transform);//Entering the plate
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            collision.transform.SetParent(null);//The character will move from the plate
        }
    }
}
