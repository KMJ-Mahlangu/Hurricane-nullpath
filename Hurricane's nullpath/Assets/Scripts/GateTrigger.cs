using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [Header("Hint Settings")]
    public string hintText;       
    public HintUI hintUI;           

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hintUI != null)
        {
            hintUI.ShowHint(hintText);   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && hintUI != null)
        {
            hintUI.HideHint();           
        }
    }
}
