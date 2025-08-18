using UnityEngine;
using System.Collections;

public class GateSlide : MonoBehaviour
{
    public Transform gate;            // assign gate object in Inspector
    public float slideDistance = -5f; // how far to slide along X (negative = left, positive = right)
    public float slideSpeed = 2f;     // speed of sliding

    private Vector3 closedPos;
    private Vector3 openPos;
    private bool isOpen = false;

    void Start()
    {
        // Remember starting position
        closedPos = gate.position;
        openPos = closedPos + new Vector3(slideDistance, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            StartCoroutine(SlideGateOpen());
        }
    }

    IEnumerator SlideGateOpen()
    {
        isOpen = true;

        // Move smoothly towards open position
        while (Vector3.Distance(gate.position, openPos) > 0.01f)
        {
            gate.position = Vector3.MoveTowards(gate.position, openPos, slideSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
