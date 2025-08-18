using UnityEngine;

public class PlayerKeyInventory : MonoBehaviour
{
    [Header("Key Settings")]
    [SerializeField] private int keysRequired = 3;
    [SerializeField] private bool showDebugMessages = true;
    private int keysCollected = 0;

    [Header("UI Feedback")]
    [SerializeField] private UnityEngine.UI.Text keysText;
    [SerializeField] private GameObject keyCollectedEffect;

    public void AddKey()
    {
        keysCollected++;
        UpdateKeysUI();

        if (keyCollectedEffect != null)
        {
            Instantiate(keyCollectedEffect, transform.position, Quaternion.identity);
        }

        if (showDebugMessages)
        {
            Debug.Log($"Key collected! ({keysCollected}/{keysRequired})", this);
        }
    }

    public bool HasAllKeys()
    {
        return keysCollected >= keysRequired;
    }

    private void UpdateKeysUI()
    {
        if (keysText != null)
        {
            keysText.text = $"Keys: {keysCollected}/{keysRequired}";
        }
    }
}