using TMPro;
using UnityEngine;

public class KeyControlledGate : MonoBehaviour
{
    [Header("Gate Settings")]
    [SerializeField] private float openSpeed = 3f;
    [SerializeField] private float slideDistance = 2f;

    [Header("UI Settings")]
    [SerializeField] private GameObject promptUI;
    [SerializeField] private TextMeshProUGUI promptText;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;
    private bool isOpen = false;
    private Collider gateCollider;

    private void Start()
    {
        gateCollider = GetComponent<Collider>();
        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.left * slideDistance;

        if(promptUI != null )
        {
            promptUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (isOpening && !isOpen)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                openPosition,
                openSpeed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, openPosition) < 0.01f)
            {
                isOpen = true;
                gateCollider.enabled = false;
                HideKeyPrompt();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpening)
        {
            PlayerKeyInventory inventory = other.GetComponent<PlayerKeyInventory>();
            if (inventory != null && inventory.HasAllKeys())
            {
                isOpening = true;
                ShowKeyPrompt("Gate Opening...");
                Debug.Log("Gate opening!");
                HideKeyPrompt();
            }
            else
            {
                ShowKeyPrompt("You need all 3 keys to open this gate!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && !isOpen)
        {
            HideKeyPrompt();
        }
    }

    private void ShowKeyPrompt(string message)
    {
        if (promptUI != null && promptText != null)
        {
            promptUI.SetActive(true);
            promptText.text = message;
        }
    }

    private void HideKeyPrompt()
    {
        if (promptUI != null)
        {
            promptUI.SetActive(false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * slideDistance);
        Gizmos.DrawWireCube(transform.position + Vector3.left * slideDistance, transform.localScale);
    }
}