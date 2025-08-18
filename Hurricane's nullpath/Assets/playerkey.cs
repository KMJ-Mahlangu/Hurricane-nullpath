using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    public bool hasKey = false;
    public GateController gate; // drag and drop your gate into inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(other.gameObject); // remove key

            // Open the gate automatically
            if (gate != null)
            {
                gate.TriggerGate();
            }
        }
    }
}
