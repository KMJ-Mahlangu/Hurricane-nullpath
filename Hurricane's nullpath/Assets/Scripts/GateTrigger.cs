using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public HintUI hintUI; 
    [TextArea] public string gateMessage = "3 Keys Are Needed To Open This Gate!";
    [TextArea] public string openingMessage = "Now opening...";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerKeyInventory inventory = GetComponent<PlayerKeyInventory>();
            if (inventory != null && inventory.HasAllKeys())
            {
                hintUI.ShowHint(openingMessage);
            }
            else
            {
                hintUI.ShowHint(gateMessage);
            }
               
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
