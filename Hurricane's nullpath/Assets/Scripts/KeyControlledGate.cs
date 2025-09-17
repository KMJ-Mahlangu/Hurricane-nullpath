using UnityEngine;
using TMPro;

public class KeyControlledGate : MonoBehaviour
{
    public string requiredKeyName;
    public GameObject gateKeyObject; // Key model on the gate
    public float openSpeed = 3f;
    public float slideDistance = 2f;
    public GameObject promptUI;
    public TextMeshProUGUI promptText;

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

        if (promptUI != null) promptUI.SetActive(false);
        if (gateKeyObject != null) gateKeyObject.SetActive(false);
    }

    private void Update()
    {
        if (isOpening && !isOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, openSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, openPosition) < 0.01f)
            {
                isOpen = true;
                gateCollider.enabled = false;
                if (promptUI != null) promptUI.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpening)
        {
            PlayerKeyInventory inventory = other.GetComponent<PlayerKeyInventory>();
            if (inventory != null && inventory.HasKey(requiredKeyName))
            {
                inventory.UseKey(requiredKeyName);
                if (gateKeyObject != null) gateKeyObject.SetActive(true);
                isOpening = true;
                if (promptText != null) promptText.text = "Gate Opening...";
                if (promptUI != null) promptUI.SetActive(true);
            }
            else
            {
                if (promptText != null) promptText.text = $"You need {requiredKeyName}!";
                if (promptUI != null) promptUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen && promptUI != null)
            promptUI.SetActive(false);
    }
}
