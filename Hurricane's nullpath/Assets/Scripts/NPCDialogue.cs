using TMPro;
using UnityEngine;
using System.Collections;

public class NPCDialogue : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string speaker;
        [TextArea(2, 5)]
        public string text;
    }

    [Header("Dialogue Settings")]
    public DialogueLine[] dialogueLines;

    [Header("UI References")]
    public GameObject dialogueUI;
    public TMP_Text speakerNameText;
    public TMP_Text dialogueText;
    public TMP_Text interactPromptText;
    public GameObject dialoguePanel;

    [Header("NPC Visibility Settings")]
    public float hideDelay = 5f;

    private int currentLine = 0;
    private bool playerInRange = false;
    private bool dialogueActive = false;
    private Coroutine hideCoroutine;

    [Header("Facing Settings")]
    public Transform player;
    public float rotationSpeed = 5f;

    private void Start()
    {
        // Make sure NPC starts disabled if needed
        if (!gameObject.activeSelf)
            gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0f; // ignore vertical difference
            if (direction.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueActive)
                StartDialogue();
            else
                DisplayNextLine();
        }
    }

    private void StartDialogue()
    {
        dialogueActive = true;
        currentLine = 0;
        dialogueUI.SetActive(true);
        dialoguePanel.SetActive(true);
        interactPromptText.gameObject.SetActive(false);

        DisplayLine();
    }

    private void DisplayLine()
    {
        DialogueLine line = dialogueLines[currentLine];
        dialogueText.text = line.text;
        speakerNameText.text = line.speaker;
    }

    private void DisplayNextLine()
    {
        currentLine++;
        if (currentLine < dialogueLines.Length)
        {
            DisplayLine();
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        dialogueActive = false;
        dialogueUI.SetActive(false);
        dialoguePanel.SetActive(false);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // Cancel any hide coroutine
            if (hideCoroutine != null)
            {
                StopCoroutine(hideCoroutine);
                hideCoroutine = null;
            }

            // Show NPC and enable prompt
            gameObject.SetActive(true);
            interactPromptText.gameObject.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactPromptText.gameObject.SetActive(false);
            dialoguePanel.SetActive(false);

            // Hide NPC after delay
            hideCoroutine = StartCoroutine(HideAfterDelay());
        }
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(hideDelay);
        gameObject.SetActive(false);
    }
}
