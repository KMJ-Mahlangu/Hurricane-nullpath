using TMPro;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        public string speaker;   // NPC or character
        [TextArea(2, 5)]
        public string text;
    }

    [Header("Dialogue Setting")]
    public DialogueLine[] dialogueLines;

    [Header("UI Reference")]
    public GameObject dialogueUI;
    public TMP_Text speakerNameText;
    public TMP_Text dialogueText;
    public TMP_Text interactPromptText;
    public GameObject dialoguePanel;

    private int currentLine = 0;
    private bool playerInRange = false;
    private bool dialogueActive = false;

  

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialoguePanel.SetActive(true);
            if (!dialogueActive)
                StartDialogue();
            else
                DisplayNextLine();
        }
    }

    void StartDialogue()
    {
        dialogueActive = true;
        currentLine = 0;
        dialogueUI.SetActive(true);
        interactPromptText.gameObject.SetActive(false); // hide during dialogue

        DisplayLine();
    }

    void DisplayLine()
    {
        DialogueLine line = dialogueLines[currentLine];
        dialogueText.text = line.text;
        speakerNameText.text = line.speaker;

    }

    void DisplayNextLine()
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

    void EndDialogue()
    {
        dialogueActive = false;
        dialogueUI.SetActive(false);
        dialoguePanel.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactPromptText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;


        }
    }
}
