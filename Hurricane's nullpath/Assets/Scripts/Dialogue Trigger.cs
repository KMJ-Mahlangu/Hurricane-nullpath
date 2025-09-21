using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    [TextArea] public string dialogueText;
    public GameObject dialoguePanel;
    public TMP_Text dialogueTextUI;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            dialoguePanel.SetActive(true);
            dialogueTextUI.text = dialogueText;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false);
            Destroy(gameObject);        }
    }
}
