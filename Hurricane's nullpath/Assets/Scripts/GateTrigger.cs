using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public HintUI hintUI; 
    [TextArea] public string gateMessage = "3 Keys Are Needed To Open This Gate!";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hintUI.ShowHint(gateMessage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hintUI.HideHint();
        }
    }
}
