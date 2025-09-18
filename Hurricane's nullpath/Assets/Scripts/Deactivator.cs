using UnityEngine;
using System.Collections;

public class Deactivator : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveDistance = 0.5f;      
    public float moveSpeed = 3f;           
    public GameObject challenge;
    public GameObject myCanvas;

    private Vector3 targetPos;
    private bool isMoving = false;


    public void Start()
    {
        myCanvas.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !isMoving)
        {
            
            Vector3 pushDir = (transform.position - other.transform.position).normalized;

            
            targetPos = transform.position + pushDir * moveDistance;

            
            StartCoroutine(MoveBlock());
        }
    }

    private IEnumerator MoveBlock()
    {
        isMoving = true;
        myCanvas.SetActive(false);
        Vector3 startPos = transform.position;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        
        if (challenge != null)
        {
            challenge.SetActive(false);
        }

        isMoving = false;
    }
}
