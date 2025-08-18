using UnityEngine;
using System.Collections;

public class GateController : MonoBehaviour
{
    public Transform gate;              // assign gate object in inspector
    public Vector3 openRotation = new Vector3(0, 90, 0);  
    public float openSpeed = 2f;
    public float openTime = 3f;

    private Quaternion closedRot;
    private bool isOpen = false;

    private void Start()
    {
        closedRot = gate.rotation;
    }

    public void TriggerGate()
    {
        if (!isOpen)
            StartCoroutine(OpenAndCloseGate());
    }

    IEnumerator OpenAndCloseGate()
    {
        isOpen = true;
        Quaternion targetRot = Quaternion.Euler(openRotation);

        // Rotate open
        while (Quaternion.Angle(gate.rotation, targetRot) > 0.1f)
        {
            gate.rotation = Quaternion.Slerp(gate.rotation, targetRot, Time.deltaTime * openSpeed);
            yield return null;
        }

        yield return new WaitForSeconds(openTime);

        // Rotate closed
        while (Quaternion.Angle(gate.rotation, closedRot) > 0.1f)
        {
            gate.rotation = Quaternion.Slerp(gate.rotation, closedRot, Time.deltaTime * openSpeed);
            yield return null;
        }

        isOpen = false;
    }
}
